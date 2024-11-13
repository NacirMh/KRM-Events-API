using KRM_Events_API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KRM_Events_API.Dtos.Account;

namespace KRM_Events_API.Dtos.Contact
{
    public class ContactDTO
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public string? UserId { get; set; }

        public UserDetailsDTO? UserDetails { get; set; }


    }
}
