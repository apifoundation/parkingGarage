using System.Threading.Tasks;

namespace GarageApp.Repositories
{
    public interface IGarageTicketRepository
    {

        Task SaveAsync(GarageTicket ticket);

        Task<GarageTicket> FindAsync(string ticketId);

    }
}