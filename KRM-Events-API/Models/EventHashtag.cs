using KRM_Events_API.Model;

namespace KRM_Events_API.Models
{
    public class EventHashtag
    {
        public int EventId { get; set; }
        public int HashtagId {  get; set; }

        public Event? Event { get; set; }

        public Hashtag? Hashtag { get; set; }
    }
}
