using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RoastingBoulevard.Models
{
    public class User
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Surname")]
        public string Surname { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Phone")]
        public int Phone { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
        public List<Address> addresses = new List<Address>();
        public List<Delivery> deliveries = new List<Delivery>();

        public User()
        {
        }

        public User(int id, string name, string surname, string email, int phone)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Phone = phone;
        }

    }
}
