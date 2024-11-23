using KRM_Events_API.Dtos.Contact;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Mappers;
using KRM_Events_API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KRM_Events_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly UserManager<AppUser> _userManager;

        public ContactController(UserManager<AppUser> userManager, IContactRepository contactRepo)
        {
            _userManager = userManager;
            _contactRepository = contactRepo;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllContacts();
            var contactsDto = contacts.Select(x=>x.ToContactDTO()).ToList();
            return Ok(contactsDto);
        }

        [Authorize(Roles = "Announcer,Client")]
        [HttpPost]
        public async Task<IActionResult> Contact(CreateContactDTO createContactDto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("This User doesn't Exist");
            }
            var contact = createContactDto.ToContactFromCreate(user.Id);
            var result = await _contactRepository.Contact(contact);
            return Ok(result.ToContactDTO());
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int ContactId)
        {
            var contact = await _contactRepository.DeleteContact(ContactId);
            if (contact == null)
            {
                return NotFound($"Contact id {ContactId} not found");
            }
            return Ok(contact);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetContactsByUserName/{UserName}")]
        public async Task<IActionResult> GetContactsByUser(string UserName)
        {
            var contacts = await _contactRepository.GetAllContacts();
            var user = await _userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                return NotFound("username Not Found");
            }
            var contactsByUser = contacts.Where(x => x.AppUser.UserName.Contains(UserName,StringComparison.OrdinalIgnoreCase));
            var contactsDto  = contactsByUser.Select(x=>x.ToContactDTO()).ToList();
            return Ok(contactsDto);
        }
    }
}
