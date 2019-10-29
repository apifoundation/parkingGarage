using System.Threading.Tasks;

namespace GarageApp.ReceiptProviders
{
    public interface IReceiptProvider
    {

        Task HandleReceiptAsync(GarageTicket ticket, string emailAddress, ReceiptFormat receiptFormat);

    }
}