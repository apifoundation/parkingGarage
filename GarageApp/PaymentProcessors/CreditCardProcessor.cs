using System;
using System.Threading.Tasks;

namespace GarageApp.PaymentProcessors
{
    public sealed class CreditCardProcessor : PaymentProcessor<CreditCard>
    {

        private readonly ICreditCardChargeService _chargeService;

        public CreditCardProcessor(ICreditCardChargeService chargeService) =>
            _chargeService = chargeService ?? throw new ArgumentNullException(nameof(chargeService));

        protected override async Task<bool> CheckInAsync(CreditCard payment) =>
            await _chargeService.IsValidAsync(payment);

        protected override async Task<bool> CheckOutAsync(CreditCard payment, GarageTicket ticket)
        {
            var checkoutTime = DateTime.Now;
            var totalHours = (checkoutTime - ticket.CheckInTime).TotalMinutes / 60;
            var totalCharge = (decimal)(10 + 2 * totalHours);

            ticket.AmountCharged = totalCharge;

            return await _chargeService.ChargeAsync(payment, totalCharge);
        }

    }
}