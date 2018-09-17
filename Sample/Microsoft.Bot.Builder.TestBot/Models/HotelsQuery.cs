﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Microsoft.Bot.Builder.FormFlow;

namespace Microsoft.Bot.Builder.TestBot.Models
{
    [Serializable]
    public class HotelsQuery
    {
        [Prompt("Please enter your {&}")]
        public string Destination { get; set; }

        [Prompt("When do you want to {&}?")]
        public DateTime CheckIn { get; set; }

        [Numeric(1, int.MaxValue)]
        [Prompt("How many {&} do you want to stay?")]
        public int Nights { get; set; }
    }
}
