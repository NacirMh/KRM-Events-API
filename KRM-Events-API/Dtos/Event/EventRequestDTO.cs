using KRM_Events_API.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Dtos.Event
{
    public class EventRequestDTO
    {
        public int Id { get; set; }

        public bool Status { get; set; } = false;

        public string Comment { get; set; } = string.Empty;

        public string AnnouncerId { get; set; }
        public EventDTO EventDTO { get; set; }
    }
}
