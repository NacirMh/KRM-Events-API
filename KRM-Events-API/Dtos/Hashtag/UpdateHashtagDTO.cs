using System.ComponentModel.DataAnnotations;

namespace KRM_Events_API.Dtos.Hashtag
{
    public class UpdateHashtagDTO
    {
        [Required]
        public string HashTagName { get; set; } = string.Empty;

        [Required]
        public string HashTagDescription { get; set; } = string.Empty;

        
    }
}
