using System.ComponentModel.DataAnnotations;

namespace KRM_Events_API.Dtos.Account
{
    public class UserDetailsDTO
    {
        
        public string? UserName { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 

        public string? City { get; set; } 
        public string? EmailAddress { get; set; } 
        public bool IsEmailConfirmed { get; set; } 
        public string? PhoneNumber { get; set; }

        public int AccessFailedCount { get; set; }
    }
}
