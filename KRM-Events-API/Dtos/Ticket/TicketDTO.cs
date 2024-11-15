using KRM_Events_API.Dtos.Account;
using KRM_Events_API.Dtos.Event;
using KRM_Events_API.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Dtos.Ticket
{
    public class TicketDTO
    {
        public int ticketId { get; set; }

        public DateTime BoughtAt { get; set; } = DateTime.Now;

        public bool IsUsedCouponCode { get; set; } = false;

        public decimal Price { get; set; }

        public UserDetailsDTO Client { get; set; }
        public int eventId { get; set; }

    }
}
