using KRM_Events_API.Dtos.Event;
using KRM_Events_API.Helpers;
using KRM_Events_API.Model;

namespace KRM_Events_API.Interfaces
{
    public interface IEventRepository
    {

        public Task<Event> GetByIdAsync(int id);

        public Task<List<Event>> GetAllAcceptedEvents(EventQueryObject queryObject);
        public Task<Event> DeleteEvent(int id);

        public Task<Event> UpdateEvent(int id, UpdateEventDTO updateEventDTO);
        public Task<bool> EventExists(int id);

    }
}
