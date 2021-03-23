using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RoastingBoulevard.Models
{
    public class Food
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Ingredients")]
        public string Ingredients { get; set; }
        [JsonProperty("Allergens")]
        public List<Allergen> allergens=new List<Allergen>();
        [JsonProperty("Photo")]
        public string Photo { get { return $"Foods/{photo}"; } set { photo = value; } }
        [JsonProperty("Price")]
        public float Price { get; set; }


        private string photo;
        public Food()
        {
        }

        public Food(int id, string name, string description, string ingredients, List<Allergen> allergens, string photo, float price)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Description = ingredients;
            this.allergens = allergens;
            this.Photo = photo;
            this.Price = price;
        }

    }
}
