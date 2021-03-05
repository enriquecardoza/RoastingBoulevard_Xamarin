using System;
namespace RoastingBoulevard.Models
{
    public class Bill
    {
        int id;
        Delivery delivery;
        float amount;
        DateTime date;


        public Bill()
        {
        }

        public Bill(int id, Delivery delivery, float amount, DateTime date)
        {
            this.id = id;
            this.delivery = delivery;
            this.amount = amount;
            this.date = date;
        }
    }
}
