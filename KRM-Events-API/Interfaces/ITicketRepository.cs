using KRM_Events_API.Model;

namespace KRM_Events_API.Interfaces
{
    public interface ITicketRepository
    {
        public Task<List<Ticket>> GetTicketsByEvent(int id);
        public Task<List<Ticket>> GetTicketsByClient(string ClientId);
        public Task<Ticket> AddTicket(Ticket ticket);

    }
}
