using KRM_Events_API.Dtos.Account;
using KRM_Events_API.Dtos.Event;
using System.ComponentModel.DataAnnotations;

namespace KRM_Events_API.Dtos.Opinion
{
    public class OpinionDTO
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

       
        public UserDetailsDTO ClientDetails { get; set; }
        public EventDTO Event { get; set; }
    }
}
