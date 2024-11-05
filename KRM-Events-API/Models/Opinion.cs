using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{
    [Table("Opinions")]
    public class Opinion
    {
        [Key]
        public int Id { get; set; }
      

        [Required]  
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string ClientId { get; set; }
        public int EventId { get; set; }
        public Client? Client { get; set; }

        public Event? Event { get; set; }
    }
}
