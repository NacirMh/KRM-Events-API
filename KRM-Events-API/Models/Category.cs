using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Model
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        public string CategoryDescription { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;

        public List<Event> Events { get; set; } = new List<Event>();

    }
}
