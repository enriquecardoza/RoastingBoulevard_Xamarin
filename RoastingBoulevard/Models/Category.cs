using System;
using System.Collections.Generic;

namespace RoasingBoulevard_Xamarin.Models
{
    public class Category
    {
        int id;
        string name;
        List<Food> foods = new List<Food>();

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
