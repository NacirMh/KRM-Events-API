using System.ComponentModel.DataAnnotations;

namespace KRM_Events_API.Dtos.Contact
{
    public class CreateContactDTO
    {
        [Required]
        public string Content { get; set; } = string.Empty;


    }
}
