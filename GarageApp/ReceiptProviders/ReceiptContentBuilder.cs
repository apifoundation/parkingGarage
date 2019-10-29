namespace GarageApp.ReceiptProviders
{
    public sealed class ReceiptContentBuilder : IReceiptContentBuilder
    {

        public string BuildContent(GarageTicket ticket)
        {
            var receiptContent = $"Check in time: {ticket.CheckInTime}\n" +
                                 $"Check out time: {ticket.CheckOutTime}\n" +
                                 $"Total charge: ${ticket.AmountCharged}";
            return receiptContent;
        }

    }
}