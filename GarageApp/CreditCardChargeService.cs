using System.Threading.Tasks;

namespace GarageApp
{
    public sealed class CreditCardChargeService : ICreditCardChargeService
    {

        public Task<bool> IsValidAsync(CreditCard creditCard) => Task.FromResult(true);

        public Task<bool> ChargeAsync(CreditCard creditCard, decimal amount) => Task.FromResult(true);

    }
}