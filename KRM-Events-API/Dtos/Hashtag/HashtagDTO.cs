using System.ComponentModel.DataAnnotations;

namespace KRM_Events_API.Dtos.Hashtag
{
    public class HashtagDTO
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string HashTagName { get; set; } = string.Empty;

        [Required]
        public string HashTagDescription { get; set; } = string.Empty;


    }
}
