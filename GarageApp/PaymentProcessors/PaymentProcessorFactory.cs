using GarageApp.Repositories;
using System;

namespace GarageApp.PaymentProcessors
{
    public sealed class PaymentProcessorFactory: IPaymentProcessorFactory
    {

        public IPaymentProcessor Create(Type paymentType)
        {
            if (paymentType == typeof(CreditCardProcessor))
            {
                // Poor's man IoC. In a real application, we would probably use a service locator
                return new CreditCardProcessor(new CreditCardChargeService());
            }
            else if (paymentType == typeof(ParkingPermit))
            {
                // Same here
                return new ParkingPermitProcessor(new ParkingPermitRepository());
            }
            else
            {
                throw new InvalidOperationException("Payment type not supported");
            }
        }

    }
}