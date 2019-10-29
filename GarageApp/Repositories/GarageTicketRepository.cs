using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageApp.Repositories
{
    public sealed class GarageTicketRepository: IGarageTicketRepository
    {

        private readonly IList<GarageTicket> _storage = new List<GarageTicket>();

        public Task SaveAsync(GarageTicket ticket)
        {
            if (!_storage.Any(t => t.TicketId == ticket.TicketId))
            {
                _storage.Add(new GarageTicket
                {
                    TicketId = ticket.TicketId,
                    CheckInTime = ticket.CheckInTime,
                    Payment = ticket.Payment
                });
            }
            return Task.FromResult(0);
        }

        public Task<GarageTicket> FindAsync(string ticketId) =>
            Task.FromResult(_storage.FirstOrDefault(t => t.TicketId == ticketId));

    }
}