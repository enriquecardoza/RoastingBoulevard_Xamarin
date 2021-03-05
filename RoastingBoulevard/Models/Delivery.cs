using System;
using System.Collections.Generic;

namespace RoastingBoulevard.Models
{
    public class Delivery
    {
       public int id;
       public List<Food> foods = new List<Food>();
       public List<int> amountsOfFoods = new List<int>();
       public Address address;
       public DateTime createdDate;
       public PaymentMethod paymentMethod;
       public DeliveryState deliveryState;

        public enum DeliveryState
        {
            Received = 0, Cooking = 1, Distribution = 2, Delivered = 3
        }
        public Delivery()
        {
        }

        public Delivery(int id, List<Food> foods, List<int> amountsOfFoods, Address address)
        {
            this.id = id;
            this.foods = foods;
            this.amountsOfFoods = amountsOfFoods;
            this.address = address;
            this.createdDate = DateTime.Now;
        }

        public void AddFood(Food food) {
            if (foods.Contains(food)){
                int pos = foods.IndexOf(food);
                amountsOfFoods[pos] += 1;
            }
            else
            {
                foods.Add(food);
                amountsOfFoods.Add(1);
            }
        }

        public void RemoveFood(Food food)
        {
            if (foods.Contains(food))
            {
                int pos = foods.IndexOf(food);
                if (amountsOfFoods[pos] - 1 == 0)
                {
                    foods.Remove(food);
                    amountsOfFoods.Remove(pos);
                }
                else
                {
                    amountsOfFoods[pos] -= 1;
                }
            }
        }
    }
}
