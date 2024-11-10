using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{
    [Table("EventRequests")]
    public class EventRequest
    {
        [Key]
        public int Id { get; set; } 

        public bool Status { get; set; } = false;

        public string Comment { get; set; } = "Pending...";

        
        [ForeignKey(nameof(Announcer))]
        public string AnnouncerId { get; set; }
        public virtual Announcer? Announcer { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public virtual Event? Event { get; set; }

    }
}
