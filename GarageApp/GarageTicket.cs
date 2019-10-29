using System;

namespace GarageApp
{
    public sealed class GarageTicket
    {

        public string TicketId { get; set; }

        public DateTime CheckInTime { get; set; }

        public DateTime CheckOutTime { get; set; }

        public PaymentInformation Payment { get; set; }

        public decimal AmountCharged { get; set; }

    }
}