using KRM_Events_API.Dtos.Account;
using KRM_Events_API.Dtos.Event;
using System.ComponentModel.DataAnnotations;

namespace KRM_Events_API.Dtos.Opinion
{
    public class OpinionDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

       
        public UserDetailsDTO ClientDetails { get; set; }
        public int EventId { get; set; }
    }
}
