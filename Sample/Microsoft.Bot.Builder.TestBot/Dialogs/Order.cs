﻿namespace Microsoft.Bot.Builder.TestBot.Dialogs
{
    using System;
  
    using Microsoft.Bot.Builder.FormFlow;
    using Microsoft.Bot.Builder.FormFlow.Advanced;
  
    public static class RegexConstants
    {
        public const string Email = @"[a-z0-9!#$%&'*+\/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+\/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

        public const string Phone = @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$";
    }
    [Serializable]
    public class Bouquet
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public string FlowerCategory { get; set; }
    }
    [Serializable]
    public class PaymentDetails
    {
        public string CreditCardHolder { get; set; }

        public string CreditCardNumber { get; set; }
    }
    [Serializable]
    public class Order
    {
        public enum UseSaveInfoResponse
        {
            Yes,
            Edit
        }

        public string OrderID { get; set; }

        [Prompt]
        public string RecipientFirstName { get; set; }

        [Prompt(FieldCase = CaseNormalization.None)]
        public string RecipientLastName { get; set; }

        [Prompt]
        [Pattern(RegexConstants.Phone)]
        public string RecipientPhoneNumber { get; set; }

        [Prompt]
        [Pattern(@"^.{1,200}$")]
        public string Note { get; set; }

        [Prompt]
        [Pattern(RegexConstants.Email)]
        public string SenderEmail { get; set; }

        [Prompt]
        [Pattern(RegexConstants.Phone)]
        public string SenderPhoneNumber { get; set; }

        public string SenderFirstName { get; set; }

        public string SenderLastName { get; set; }

        public bool AskToUseSavedSenderInfo { get; set; }

        [Prompt]
        public UseSaveInfoResponse? UseSavedSenderInfo { get; set; }

        [Prompt]
        public bool SaveSenderInfo { get; set; }

        public string DeliveryAddress { get; set; }

        public string FlowerCategoryName { get; set; }

        public Bouquet Bouquet { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string BillingAddress { get; set; }

        public bool Payed { get; set; }

        public PaymentDetails PaymentDetails { get; set; }

        public static IForm<Order> BuildOrderForm()
        {
            return new FormBuilder<Order>()
                .Field(nameof(RecipientFirstName))
                .Field(nameof(RecipientLastName))
                .Field(nameof(RecipientPhoneNumber))
                .Field(nameof(Note))
                .Field(new FieldReflector<Order>(nameof(UseSavedSenderInfo))
                    .SetActive(state => state.AskToUseSavedSenderInfo)
                    .SetNext((value, state) =>
                    {
                        var selection = (UseSaveInfoResponse)value;

                        if (selection == UseSaveInfoResponse.Edit)
                        {
                            state.SenderEmail = null;
                            state.SenderPhoneNumber = null;
                            return new NextStep(new[] { nameof(SenderEmail) });
                        }
                        else
                        {
                            return new NextStep();
                        }
                    }))
                .Field(new FieldReflector<Order>(nameof(SenderEmail))
                    .SetActive(state => !state.UseSavedSenderInfo.HasValue || state.UseSavedSenderInfo.Value == UseSaveInfoResponse.Edit)
                    .SetNext(
                        (value, state) => (state.UseSavedSenderInfo == UseSaveInfoResponse.Edit)
                        ? new NextStep(new[] { nameof(SenderPhoneNumber) })
                        : new NextStep()))
                .Field(nameof(SenderPhoneNumber), state => !state.UseSavedSenderInfo.HasValue || state.UseSavedSenderInfo.Value == UseSaveInfoResponse.Edit)
                .Field(nameof(SaveSenderInfo), state => !state.UseSavedSenderInfo.HasValue || state.UseSavedSenderInfo.Value == UseSaveInfoResponse.Edit)
                .Build();
        }
    }
}
