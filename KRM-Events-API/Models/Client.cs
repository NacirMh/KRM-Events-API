using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{
    [Table("Clients")]
    public class Client : AppUser
    {
        public virtual List<Favorite> favorites { get; set; } = new List<Favorite>();
        public virtual List<Opinion> Opinions { get; set; } = new List<Opinion>();
        public virtual List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual List<ClientAnnouncer> ClientAnnouncers { get; set; } = new List<ClientAnnouncer>();

    }
}
