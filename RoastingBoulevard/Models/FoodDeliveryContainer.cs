using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoastingBoulevard.Models
{
    public class FoodDeliveryContainer
    {
        [JsonProperty("Food")]
        public Food Food { get; set; }
        [JsonProperty("Amount")]
        public int Amount { get; set; }
    }
}
