using System;
using RoastingBoulevard.Models;

namespace RoastingBoulevard.Data
{
    public static class SharedData
    {
        public static User user;
        public static bool loggedUser=> user != null;
        public static Delivery actualDelivery;
        public static Delivery deliveringDelivery;
        public static bool delivering => deliveringDelivery != null;
    }
}
