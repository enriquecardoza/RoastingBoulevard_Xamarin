using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RoastingBoulevard.Models
{
    public class Category
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Foods")]
        public List<Food> Foods { get => foods; set => foods = value; }
        private List<Food> foods = new List<Food>();

        public Category()
        {
        }

        public Category(int id, string name, List<Food> foods)
        {
            this.Id = id;
            this.Name = name;
            this.Foods = foods;
        }
    }
}
