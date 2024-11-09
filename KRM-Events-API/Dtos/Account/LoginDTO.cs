using System.ComponentModel.DataAnnotations;

namespace KRM_Events_API.Dtos.Account
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string? Email {  get; set; }

        [Required]
        public string? password { get; set; }    
    }
}
