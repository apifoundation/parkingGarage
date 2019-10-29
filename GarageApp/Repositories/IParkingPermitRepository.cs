using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Repositories
{
    public interface IParkingPermitRepository
    {

        Task<ParkingPermit> FindAsync(string permitId);

        Task RecordCheckInAsync(ParkingPermit permit);

        Task RecordCheckoutAsync(ParkingPermit permit);

    }
}
