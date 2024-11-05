using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{

    [Table("ClientAnnouncerFollow")]
    public class ClientAnnouncer
    {
         public string ClientId { get; set; }
         public string AnnouncerId {  get; set; }

         public Client? Client { get; set; }

         public Announcer? Announcer { get; set; }
    }
}
