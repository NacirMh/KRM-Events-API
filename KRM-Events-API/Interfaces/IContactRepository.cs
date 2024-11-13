using KRM_Events_API.Model;

namespace KRM_Events_API.Interfaces
{
    public interface IContactRepository
    {
        public Task<List<Contact>> GetAllContacts();
        public Task<List<Contact>> GetContactsByUserId(string username);
        public Task<Contact> Contact(Contact contact);
        public Task<Contact> DeleteContact(int contactId);
    }
}
