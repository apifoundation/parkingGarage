using GarageApp.PaymentProcessors;
using GarageApp.ReceiptProviders;
using GarageApp.Repositories;
using System;
using System.Threading.Tasks;

namespace GarageApp
{
    public sealed class GarageParking
    {

        private readonly IGarageTicketRepository _repository;

        private readonly IPaymentProcessorFactory _factory;

        private readonly IReceiptProvider _receiptProvider;

        public GarageParking(IGarageTicketRepository repository, IPaymentProcessorFactory factory,
                             IReceiptProvider receiptProvider)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _receiptProvider = receiptProvider ?? throw new ArgumentNullException(nameof(receiptProvider));
        }

        public async Task<string> CheckInAsync(PaymentInformation payment)
        {

            var processor = _factory.Create(payment.GetType());

            var receptId = await processor.CheckInAsync(payment) ? Guid.NewGuid().ToString() : null;

            if (receptId != null)
            {
                var ticket = new GarageTicket
                {
                    Payment = payment,
                    CheckInTime = DateTime.Now,
                    TicketId = receptId
                };
                await _repository.SaveAsync(ticket);
            }
            return receptId;
        }

        public async Task CheckOutAsync(string ticketId, string emailAddress, ReceiptFormat receiptFormat)
        {
            var ticket = await _repository.FindAsync(ticketId);
            if (ticket == null)
            {
                throw new InvalidOperationException("Ticket not found");
            }

            ticket.CheckOutTime = DateTime.Now;
            var processor = _factory.Create(ticket.Payment.GetType());
            await processor.CheckOutAsync(ticket);

            await _receiptProvider.HandleReceiptAsync(ticket, emailAddress, receiptFormat);
        }

    }
}