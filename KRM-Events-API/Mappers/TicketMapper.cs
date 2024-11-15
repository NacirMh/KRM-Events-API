using KRM_Events_API.Dtos.Ticket;
using KRM_Events_API.Model;

namespace KRM_Events_API.Mappers
{
    public static class TicketMapper
    {
        public static TicketDTO ToTicketDto(this Ticket ticket)
        {
            return new TicketDTO
            {
                BoughtAt = ticket.BoughtAt,
                Client = ticket.Client.ToUserDetailsFromUser(),
                Price = ticket.Price,
                eventId = ticket.EventId,
                ticketId = ticket.Id,
                IsUsedCouponCode = ticket.IsUsedCouponCode,
                
            };
        }

    }
}
