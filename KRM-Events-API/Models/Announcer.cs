using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{
    [Table("Announcers")]
    public class Announcer : AppUser
    {

        public virtual List<EventRequest> EventRequests { get; set; } = new List<EventRequest>();

        public virtual List<ClientAnnouncer> ClientAnnouncers { get; set; } = new List<ClientAnnouncer>();

    }
}
