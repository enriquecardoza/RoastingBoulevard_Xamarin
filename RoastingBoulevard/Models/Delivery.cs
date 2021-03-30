using System;
using System.Collections.Generic;

namespace RoastingBoulevard.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public List<FoodDeliveryContainer> Foods { get { return _foods; } set { _foods = value; } }
        private List<FoodDeliveryContainer> _foods = new List<FoodDeliveryContainer>();
        public DateTime CreatedDate { get; set; }
        public int PaymentMethodId { get; set; }
        public int DeliveryState { get; set; }
        public int UserId { get; set; }

        public enum DeliveryStateEnum
        {
            Received = 0, Cooking = 1, Distribution = 2, Delivered = 3
        }



    }
}
