using System;
using Newtonsoft.Json;

namespace RoastingBoulevard.Models
{
    public class Allergen
    {

        [JsonProperty("Id")]
        int id { get; set; }
        [JsonProperty("Key")]
        string key { get; set; }
    }
}
