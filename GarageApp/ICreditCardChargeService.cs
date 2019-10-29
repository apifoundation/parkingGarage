using System.Threading.Tasks;

namespace GarageApp
{
    public interface ICreditCardChargeService
    {

        Task<bool> IsValidAsync(CreditCard creditCard);

        Task<bool> ChargeAsync(CreditCard creditCard, decimal amount);
    }
}