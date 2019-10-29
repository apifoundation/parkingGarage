using System;
using System.Threading.Tasks;

namespace GarageApp.PaymentProcessors
{
    public interface IPaymentProcessor
    {
        public Task<bool> CheckInAsync(PaymentInformation payment);

        public Task<bool> CheckOutAsync(GarageTicket ticket);

    }

    public abstract class PaymentProcessor<T> : IPaymentProcessor where T : PaymentInformation
    {

        protected PaymentProcessor()
        { }

        public async Task<bool> CheckInAsync(PaymentInformation payment) =>
            await CheckInAsync((T)payment);

        public async Task<bool> CheckOutAsync(GarageTicket ticket) =>
            await CheckOutAsync((T)ticket.Payment, ticket);

        protected abstract Task<bool> CheckInAsync(T payment);

        protected abstract Task<bool> CheckOutAsync(T payment, GarageTicket ticket);

    }
}