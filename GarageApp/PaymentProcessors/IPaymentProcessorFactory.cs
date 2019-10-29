using System;

namespace GarageApp.PaymentProcessors
{
    public interface IPaymentProcessorFactory
    {

        IPaymentProcessor Create(Type paymentType);

    }
}