namespace GarageApp.ReceiptProviders
{
    public interface IReceiptContentBuilder
    {

        string BuildContent(GarageTicket ticket);

    }
}