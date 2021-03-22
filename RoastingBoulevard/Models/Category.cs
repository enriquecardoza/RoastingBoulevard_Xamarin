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

        public List<FoodCombine> CombinedList
        {
            get
            {
                listaCombinada = new List<FoodCombine>();
                for (int i = 0; i < Foods.Count; i += 2)
                {
                    if (i < Foods.Count)
                        listaCombinada.Add(new FoodCombine(Foods[i], Foods[i + 1]));
                    else
                        listaCombinada.Add(new FoodCombine(Foods[i], null));
                }
                return listaCombinada;
            }
            set { listaCombinada = value; }
        }
        private List<FoodCombine> listaCombinada = new List<FoodCombine>();
    }
}
