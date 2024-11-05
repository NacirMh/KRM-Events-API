using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [ForeignKey(nameof(AppUser))]
        public string UserId { get; set; } 

        public AppUser? AppUser { get; set; }


    }
}
