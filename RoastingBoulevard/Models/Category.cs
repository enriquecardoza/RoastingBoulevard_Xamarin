using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RoastingBoulevard.Models
{
    public class Category
    {
        [JsonProperty("Id")]
        public int id;
        [JsonProperty("Name")]
        public string name;
        [JsonProperty("Foods")]
        public List<Food> foods = new List<Food>();

        public Category()
        {
        }

        public Category(int id, string name, List<Food> foods)
        {
            this.id = id;
            this.name = name;
            this.foods = foods;
        }
    }
}
