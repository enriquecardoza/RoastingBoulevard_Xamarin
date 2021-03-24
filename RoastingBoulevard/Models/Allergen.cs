using System;
using Newtonsoft.Json;

namespace RoastingBoulevard.Models
{
    public class Allergen
    {

        [JsonProperty("Id")]
        public int id { get; set; }
        [JsonProperty("Key")]
        public string key { get; set; }


    }
}
