using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{
    [Table("Favorites")]
    public class Favorite
    {
        public string ClientId { get; set; }
        public int EventId { get; set; }

        public virtual Client? Client { get; set; }

        public virtual Event? Event { get; set; }
    }
}
