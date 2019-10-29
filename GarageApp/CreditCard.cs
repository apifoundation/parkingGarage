using System;

namespace GarageApp
{
    public sealed class CreditCard : PaymentInformation
    {

        public string Number { get; set; }

        public DateTime Expiration { get; set; }

    }
}