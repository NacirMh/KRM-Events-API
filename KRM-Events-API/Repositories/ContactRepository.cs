using KRM_Events_API.Data;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Model;
using Microsoft.EntityFrameworkCore;

namespace KRM_Events_API.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _dbContext;

        public ContactRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contact> Contact(Contact contact)
        {
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> DeleteContact(int ContactId)
        {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == ContactId);
            if (contact == null)
            {
                return null;
            }
            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            var contacts = await _dbContext.Contacts.ToListAsync();
            return contacts;
        }

        public async Task<List<Contact>> GetContactsByUserId(string userId)
        {
            var contacts = await _dbContext.Contacts.Where(x=>x.UserId == userId).ToListAsync();
            if (contacts == null)
            {
                return null;
            }
            return contacts;
        }

        public async Task<Contact> GetContactById(int contactId)
        {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == contactId);
            if (contact == null)
            {
                return null;
            }
            return contact;
        }
    }
}
