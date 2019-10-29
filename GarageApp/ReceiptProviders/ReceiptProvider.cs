using System;
using System.Threading.Tasks;

namespace GarageApp.ReceiptProviders
{
    public sealed class ReceiptProvider
    {

        private readonly IEmailClient _emailClient;

        private readonly IDevice _deviceClient;

        private readonly IReceiptContentBuilder _contentBuilder;

        public ReceiptProvider(IEmailClient emailClient, IDevice deviceClient,
                               IReceiptContentBuilder contentBuilder)
        {
            _emailClient = emailClient ?? throw new ArgumentNullException(nameof(emailClient));
            _deviceClient = deviceClient ?? throw new ArgumentNullException(nameof(deviceClient));
            _contentBuilder = contentBuilder ?? throw new ArgumentNullException(nameof(contentBuilder));
        }

        public async Task HandleReceiptFor(GarageTicket ticket, string emailAddress, ReceiptFormat receiptFormat)
        {
            if (ticket.Payment is ParkingPermit permit)
            {
                // Simplistic approach: parking permit does not generate receipt
                return;
            }

            var receiptContent = _contentBuilder.BuildContent(ticket);
            switch (receiptFormat)
            {
                case ReceiptFormat.Email:

                    await _emailClient.EmailAsync(emailAddress, receiptContent);
                    break;

                case ReceiptFormat.Print:

                    await _deviceClient.PrintAsync(receiptContent);
                    break;
            }
        }

    }
}