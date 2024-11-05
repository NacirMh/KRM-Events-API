using Microsoft.AspNetCore.Identity;

namespace KRM_Events_API.Model
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string City { get; set; }


         
        public List<Contact> contacts {  get; set; } = new List<Contact>();
    }
}
