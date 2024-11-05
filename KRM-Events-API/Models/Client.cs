using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{
    [Table("Clients")]
    public class Client : AppUser
    {
        public List<Favorite> favorites { get; set; } = new List<Favorite>();
        public List<Opinion> Opinions { get; set; } = new List<Opinion>();
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public List<ClientAnnouncer> ClientAnnouncers { get; set; } = new List<ClientAnnouncer>();

    }
}
