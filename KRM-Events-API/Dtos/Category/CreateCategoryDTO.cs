using System.ComponentModel.DataAnnotations;

namespace KRM_Events_API.Dtos.Category
{
    public class CreateCategoryDTO
    {
        [Required]
        [MinLength(3)]
        
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        [MinLength(10)]
        public string CategoryDescription { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;
    }
}
