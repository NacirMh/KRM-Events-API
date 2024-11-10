using KRM_Events_API.Data;
using KRM_Events_API.Dtos.Event;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace KRM_Events_API.Repositories
{
    public class EventRequestRepository : IEventRequestRepository
    {
        private readonly AppDbContext _DbContext;
        public EventRequestRepository(AppDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<EventRequest> AcceptRequest(int id , AcceptEventRequestDTO accEventDto)
        {
            var eventRequest = await _DbContext.EventRequests.FirstOrDefaultAsync(x => x.Id == id);
            if (eventRequest == null) {
                return null;
            }
            eventRequest.Status = accEventDto.status;
            eventRequest.Comment = accEventDto.message;
            await _DbContext.SaveChangesAsync();
            return eventRequest;
        }

        public Task<EventRequest> AcceptRequest(int id, EventRequest accEventDto)
        {
            throw new NotImplementedException();
        }

        public async Task<EventRequest> DeleteRequest(int id)
        {
            var eventRequest = await _DbContext.EventRequests.FirstOrDefaultAsync(x => x.Id == id);
            if (eventRequest == null)
            {
                return null;
            }
            _DbContext.EventRequests.Remove(eventRequest);  
            await _DbContext.SaveChangesAsync();
            return eventRequest;
        }

        public async Task<List<EventRequest>> GetAllRequests()
        {
            var eventRequests =await _DbContext.EventRequests.ToListAsync();
            return eventRequests;
        }

        public async Task<EventRequest> GetRequestById(int id)
        {
            var eventRequest =  await _DbContext.EventRequests.FirstOrDefaultAsync(x => x.Id == id);
            await _DbContext.SaveChangesAsync();
            return eventRequest;
        }

        public async Task<EventRequest> MakeRequest(EventRequest request)
        {
            await _DbContext.EventRequests.AddAsync(request);
            await _DbContext.SaveChangesAsync();
            return request;
        }

       
    }
}
