using System;
using RoastingBoulevard.Models;

namespace RoastingBoulevard.Models
{
    public class FoodCombine
    {
        private Food food1;
        private Food food2;

        public Food Food1 { get => food1; set => food1 = value; }
        public Food Food2 { get => food2; set => food2 = value; }

        public FoodCombine(Food food1, Food food2)
        {
            this.Food1 = food1;
            this.Food2 = food2;
        }

    }
}
