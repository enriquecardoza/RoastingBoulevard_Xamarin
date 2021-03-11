using System;
using System.Collections.Generic;

namespace RoastingBoulevard.Models
{
    public class User
    {
        public int id;
        public string name;
        public string surname;
        public string email;
        public int phone;
        public string password;
        public List<Address> addresses = new List<Address>();
        public List<Delivery> deliveries = new List<Delivery>();

        public User()
        {
        }

        public User(int id, string name, string surname, string email, int phone)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phone = phone;
        }

        public User(int id, string name, string surname, string email, int phone, List<Address> addresses, List<Delivery> deliveries) : this(id, name, surname, email, phone)
        {
            this.addresses = addresses;
            this.deliveries = deliveries;
        }

        public void RemoveAddress(Address address)
        {
            addresses.Remove(address);
        }
        public void AddAddress(Address address)
        {
            addresses.Add(address);
        }
        public void AddDelivery(Delivery delivery)
        {
            deliveries.Add(delivery);
        }
    }
}
