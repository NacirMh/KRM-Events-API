using KRM_Events_API.Dtos.Event;
using KRM_Events_API.Model;

namespace KRM_Events_API.Interfaces
{
    public interface IEventRequestRepository
    {

        public Task<List<EventRequest>> GetAllRequests();
        public Task<EventRequest> GetRequestById(int id);
        public Task<EventRequest> DeleteRequest(int id);
        public Task<EventRequest> MakeRequest(EventRequest request);
        public Task<EventRequest> AcceptRequest(int id , EventRequest accEventDto);

    }
}
