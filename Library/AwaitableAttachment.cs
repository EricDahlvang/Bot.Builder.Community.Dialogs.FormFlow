﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;

namespace Bot.Builder.Community.FormFlow.Advanced
{
    [Serializable]
    public class AwaitableAttachment : IAwaitable<Stream>, IAwaiter<Stream>, ISerializable
    {
        private readonly IAwaiter<Stream> awaiter;

        private readonly Attachment attachment;

        public AwaitableAttachment(Attachment attachment)
        {
            this.attachment = attachment;

            this.awaiter = Awaitable.FromSource(attachment, this.ResolveFromSourceAsync) as IAwaiter<Stream>;
        }

        public Attachment Attachment
        {
            get
            {
                return this.attachment;
            }
        }

        protected AwaitableAttachment(SerializationInfo info, StreamingContext context)
        {
            // constructor arguments
            var jsonAttachment = default(string);

            SetField.NotNullFrom(out jsonAttachment, nameof(this.attachment), info);
            this.attachment = JsonConvert.DeserializeObject<Attachment>(jsonAttachment);

            this.awaiter = Awaitable.FromSource(this.attachment, this.ResolveFromSourceAsync) as IAwaiter<Stream>;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // constructor arguments
            info.AddValue(nameof(this.attachment), JsonConvert.SerializeObject(this.attachment));
        }

        public bool IsCompleted
        {
            get
            {
                return this.awaiter.IsCompleted;
            }
        }

        public IAwaiter<Stream> GetAwaiter()
        {
            return this.awaiter;
        }

        public Stream GetResult()
        {
            throw new NotImplementedException();
        }

        public void OnCompleted(Action continuation)
        {
            throw new NotImplementedException();
        }

        public virtual string ProvideHelp<T>(IField<T> field) where T : class
        {
            var help = string.Empty;
            foreach (var validator in this.GetValidators(field))
            {
                help += $"{Environment.NewLine}- {validator.ProvideHelp()}";
            }

            // TODO: if field.Optional then display hint/tip that it can be skipped with 'none', for example

            return help;
        }

        public virtual async Task<ValidateResult> ValidateAsync<T>(IField<T> field, T state) where T : class
        {
            var result = new ValidateResult { IsValid = true, Value = this };

            var errorMessage = default(string);
            foreach (var validator in this.GetValidators(field))
            {
                var isValid = await validator.IsValidAsync(this.attachment, out errorMessage);
                if (!isValid)
                {
                    result.IsValid = false;

                    result.Feedback = result.Feedback ?? string.Empty;
                    result.Feedback += $"{Environment.NewLine}{errorMessage}";
                }
            }

            return result;
        }

        protected virtual async Task<Stream> ResolveFromSourceAsync(Attachment source)
        {
            if (!string.IsNullOrWhiteSpace(source.ContentUrl))
            {
                using (var client = new HttpClient())
                {
					// TODO: add header to HttpClient to files can be retrieved
                    //if (Microsoft​App​Credentials.IsTrustedServiceUrl(source.ContentUrl))
                    //{
                    //    await client.AddAPIAuthorization();
                    //}

                    var stream = await client.GetStreamAsync(source.ContentUrl);
                    var ms = new MemoryStream();
                    stream.CopyTo(ms);
                    ms.Position = 0;
                    return ms;
                }
            }

            return null;
        }

        private IEnumerable<AttachmentValidatorAttribute> GetValidators<T>(IField<T> field) where T : class
        {
            var typeField = field.Form.GetType().GetGenericArguments()[0].GetField(field.Name, BindingFlags.Public | BindingFlags.Instance);

            var validators = typeField.GetCustomAttributes<AttachmentValidatorAttribute>(true);
            foreach (var validator in validators)
            {
                validator.Configuration = field.Form.Configuration;
            }

            return validators;
        }
    }
}
