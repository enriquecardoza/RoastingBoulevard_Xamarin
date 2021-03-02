using System;
namespace RoasingBoulevard_Xamarin.Classes
{
    public class PaymentMethod
    {
        public Method method;
        public int creditCardNumber;
        public DateTime expirationDate;
        public int cvv;

        public PaymentMethod()
        {

        }

        public PaymentMethod(Method method)
        {
            this.method = method;
        }

        public PaymentMethod(Method method, int creditCardNumber, DateTime expirationDate, int cvv) : this(method)
        {
            this.creditCardNumber = creditCardNumber;
            this.expirationDate = expirationDate;
            this.cvv = cvv;
        }

        public enum Method
        {
            Cash = 0, MasterCard = 1, Visa = 2
        }

    }
}
