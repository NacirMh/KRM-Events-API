using KRM_Events_API.Dtos.Category;
using KRM_Events_API.Dtos.Contact;
using KRM_Events_API.Model;
using System.Reflection.Metadata.Ecma335;

namespace KRM_Events_API.Mappers
{
    public static class ContactMapper
    {
        public static Contact ToContactFromCreate(this CreateContactDTO createDto , string UserId )
        {
            return new Contact
            {
                Content = createDto.Content,
                Title = createDto.Title,
                UserId = UserId
            };
        }

        public static ContactDTO ToContactDTO(this Contact contact) {

            return new ContactDTO
            {
                Content = contact.Content,
                UserId = contact.UserId,
                Id = contact.Id,
                UserDetails = contact.AppUser.ToUserDetailsFromUser(),
                Title = contact.Title,

            };
        }
    }
}
