using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{
    [Table("Tickets")]
    public class Ticket
    {
       
        public DateTime BoughtAt { get; set; } = DateTime.Now;

        public bool IsUsedCouponCode { get; set; } = false;


        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public Client Client { get; set; }


        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public Event? Event { get; set; }
    
    }
}
