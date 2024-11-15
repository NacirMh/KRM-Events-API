using KRM_Events_API.Dtos.Ticket;
using KRM_Events_API.Model;

namespace KRM_Events_API.Interfaces
{
    public interface ITicketingService
    {

        public Task<Ticket> BuyTicket(int eventID, string ClientId, int CouponCodeId, bool IsUsedCouponCode);
        public Task<List<Ticket>> GetTicketsByEvent(int EventId);

        public Task<List<Ticket>> GetTicketsByClient(string ClientId);


    }
}
