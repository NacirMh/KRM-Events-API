using KRM_Events_API.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Dtos.Event
{
    public class CreateEventRequestDTO
    {
        public bool Status { get; set; } = false;

        public string Comment { get; set; } = "Pending...";

        public string AnnouncerId { get; set; }

        public EventDTO Event { get; set; }
    }
}
