using System;
using System.Collections.Generic;
using RoastingBoulevard.Models;

namespace RoastingBoulevard.Data
{
    public class SharedData
    {
        public static User user;
        public static bool loggedUser=> user != null;
        public static Delivery actualDelivery = new Delivery();
        public static Delivery deliveringDelivery;
        public static bool delivering => deliveringDelivery != null;

      
    }
}
