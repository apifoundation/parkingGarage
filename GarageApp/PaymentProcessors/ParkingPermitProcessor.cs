using GarageApp.Repositories;
using System;
using System.Threading.Tasks;

namespace GarageApp.PaymentProcessors
{
    public sealed class ParkingPermitProcessor : PaymentProcessor<ParkingPermit>
    {

        private readonly IParkingPermitRepository _repository;

        public ParkingPermitProcessor(IParkingPermitRepository repository) =>
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        protected override async Task<bool> CheckInAsync(ParkingPermit payment)
        {
            var savedPermit = await _repository.FindAsync(payment.Id);
            if (savedPermit != null)
            {
                await _repository.RecordCheckInAsync(savedPermit);
            }

            // This is very simplistic, in a real world application we would check
            // if the permit is valid, non-expired, etc.
            return savedPermit != null;

        }

        protected override async Task<bool> CheckOutAsync(ParkingPermit payment, GarageTicket ticket)
        {
            await _repository.RecordCheckoutAsync(payment);
            // Parking permit is charged monthly, not each time garage is used.
            ticket.AmountCharged = 0m;

            // Again, this is for simplicity. In a real app, permit would need to be
            // validated, then make sure we are not duplicating the checkout or if there
            // is a pending checkout (what if someone is borrowing a permit to allow
            // other people exit without paying)
            return true;
        }
    }
}