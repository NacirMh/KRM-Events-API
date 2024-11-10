using KRM_Events_API.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Models
{
    public class EventHashtag
    {
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        [ForeignKey(nameof(Hashtag))]
        public int HashtagId {  get; set; }

        public virtual Event? Event { get; set; }

        public virtual Hashtag? Hashtag { get; set; }
    }
}
