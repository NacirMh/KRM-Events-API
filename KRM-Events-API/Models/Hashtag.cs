using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{
    [Table("Hashtags")]
    public class Hashtag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string HashTagName { get; set; } = string.Empty;

        [Required]
        public string HashTagDescription { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; } 

        public Event? Event { get; set; }
 
    }
}
