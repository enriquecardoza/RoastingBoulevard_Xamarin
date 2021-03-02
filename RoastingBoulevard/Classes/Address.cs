using System;
namespace RoasingBoulevard_Xamarin.Classes
{
    public class Address
    {
       public string label;
       public string address;
       public int number;
       public int postalCode;
       public string city;
       public string descriptionZoneType;
      
       public string addressWithNumber => $"{address} {number}";



        public Address()
        {
        }

        public Address(string label, string address, int number, int postalCode, string city)
        {
            this.label = label;
            this.address = address;
            this.number = number;
            this.postalCode = postalCode;
            this.city = city;
        }

        public Address(string label, string address, int number, int postalCode, string city, string descriptionZoneType) : this(label, address, number, postalCode, city)
        {
            this.descriptionZoneType = descriptionZoneType;
        }

    }
}
