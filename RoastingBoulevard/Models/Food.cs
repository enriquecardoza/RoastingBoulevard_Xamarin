using System;
using System.Collections;
using System.Collections.Generic;

namespace RoastingBoulevard.Models
{
    public class Food
    {
       public int id;
        private string name;
        public string description;
       public string ingredients;
       public List<Allergen> allergens=new List<Allergen>();
        private string photo;
        public float price;

        public string Name { get => name; set => name = value; }
        public string Photo { get => photo; set => photo = value; }

        public enum Allergen
        {
            Gluten = 0, Eggs = 1, Dairy = 2, Nuts = 3, Fish = 4, Seafood = 5
        }
        public Food()
        {
        }

        public Food(int id, string name, string description, string ingredients, List<Allergen> allergens, string photo, float price)
        {
            this.id = id;
            this.Name = name;
            this.description = description;
            this.ingredients = ingredients;
            this.allergens = allergens;
            this.Photo = photo;
            this.price = price;
        }

    }
}
