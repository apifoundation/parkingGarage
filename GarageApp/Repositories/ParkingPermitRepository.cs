using System.Threading.Tasks;

namespace GarageApp.Repositories
{
    public sealed class ParkingPermitRepository : IParkingPermitRepository
    {

        public Task<ParkingPermit> FindAsync(string permitId) =>
            Task.FromResult(new ParkingPermit
            {
                Id = permitId
            });

        public Task RecordCheckInAsync(ParkingPermit permit) =>
            Task.FromResult(0);

        public Task RecordCheckoutAsync(ParkingPermit permit) =>
            Task.FromResult(0);

    }
}