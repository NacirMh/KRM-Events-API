using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public int Id { get; set; } 
        
        public DateTime BoughtAt { get; set; } = DateTime.Now;

        public bool IsUsedCouponCode { get; set; } = false;


        public decimal Price { get; set; }


        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }


        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public virtual Event? Event { get; set; }
    
    }
}
