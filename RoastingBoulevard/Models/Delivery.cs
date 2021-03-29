using System;
using System.Collections.Generic;

namespace RoastingBoulevard.Models
{
    public class Delivery
    {
       public int id;
       public List<FoodDeliveryContainer> foods = new List<FoodDeliveryContainer>();
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


       
    }
}
