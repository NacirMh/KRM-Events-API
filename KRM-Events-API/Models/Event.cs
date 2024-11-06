using KRM_Events_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{
    [Table("Events")]
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string City { get; set; } = string.Empty ;
        public string Adresse { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int capacity { get; set; } 
      

        [ForeignKey(nameof(Category))]
        public int CategoryId {  get; set; }

        public Category? Category { get; set; }

        [Required]
        [ForeignKey(nameof(Event))]
        public int EventRequestId { get; set; }
        public EventRequest EventRequest { get; set; }

        public List<CouponCode> CouponCodes { get; set; } = new List<CouponCode>();

        public List<Favorite> favorites { get; set; } = new List<Favorite>();

        public List<Opinion> Opinions { get; set; } = new List<Opinion>();

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();

        public List<EventHashtag> EventHashtags { get; set;} = new List<EventHashtag>();



    }
}
