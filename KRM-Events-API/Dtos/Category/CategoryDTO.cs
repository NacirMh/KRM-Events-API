using KRM_Events_API.Dtos.Event;
using KRM_Events_API.Model;
using System.ComponentModel.DataAnnotations;

namespace KRM_Events_API.Dtos.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        public string CategoryDescription { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;

        public List<EventDTO> Events { get; set; } = new List<EventDTO>();
    }
}
