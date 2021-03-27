using Newtonsoft.Json;
using System.Collections.Generic;

namespace RoastingBoulevard.Models
{
    public class User
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("NAME")] public string Name { get; set; }
        [JsonProperty("SURNAME")]public string Surname { get; set; }
        [JsonProperty("EMAIL")] public string Email { get; set; }
        [JsonProperty("PHONE")]public int Phone { get; set; }
        [JsonProperty("PASSWORD")]public string Password { get; set; }
        [JsonProperty("ADDRESS")] public string Address { get; set; }
        [JsonProperty("NUMBER")] public int Number { get; set; }
        [JsonProperty("POSTALCODE")] public int PostalCode { get; set; }
        [JsonProperty("CITY")] public string City { get; set; }
        [JsonProperty("DESCRIPTION_ADDRESS")] public string Description_Address { get; set; }

        public List<Delivery> deliveries = new List<Delivery>();


    }
}
