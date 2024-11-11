using KRM_Events_API.Data;
using KRM_Events_API.Dtos.Event;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Mappers;
using KRM_Events_API.Model;
using KRM_Events_API.Models;
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

        public async Task<EventRequest> AcceptRequest(int id, AcceptEventRequestDTO accEventDto)
        {
            var eventRequest = await _DbContext.EventRequests.FirstOrDefaultAsync(x => x.Id == id);
            if (eventRequest == null)
            {
                return null;
            }
            eventRequest.Status = accEventDto.status;
            eventRequest.Comment = accEventDto.message ?? "";
            await _DbContext.SaveChangesAsync();
            return eventRequest;
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
            var eventRequests = await _DbContext.EventRequests.ToListAsync();
            return eventRequests;
        }

        public async Task<EventRequest> GetRequestById(int id)
        {
            var eventRequest = await _DbContext.EventRequests.FirstOrDefaultAsync(x => x.Id == id);
            if (eventRequest == null)
            {
                return null;
            }
            await _DbContext.SaveChangesAsync();
            return eventRequest;
        }

        public async Task<EventRequest> MakeRequest(string AnnouncerId, CreateEventDTO requestDto)
        {
            var Event = await _DbContext.Events.AddAsync(requestDto.ToEventFromCreateEventDTO());
            await _DbContext.SaveChangesAsync();
            var CreatedEvent = await _DbContext.Events.FindAsync(Event.Entity.Id);
            if (requestDto.HashtagsIds.Any()) {

                foreach (int HashtagId in requestDto.HashtagsIds)
                {
                    if (await _DbContext.Hashtags.FirstOrDefaultAsync(x => x.Id == HashtagId) != null)
                    {
                        var hashtagEvent = new EventHashtag { EventId = CreatedEvent.Id , HashtagId = HashtagId };
                        Event.Entity.EventHashtags.Add(hashtagEvent);
                    }
                }
            }
            var EventRequest = new EventRequest
            {
                 AnnouncerId = AnnouncerId,
                 EventId = CreatedEvent.Id,             
            };

            var eventRequest =  await _DbContext.EventRequests.AddAsync(EventRequest);
            CreatedEvent.EventRequestId = eventRequest.Entity.EventId;
            await _DbContext.SaveChangesAsync();  

            return EventRequest;
        }

        
    }
}
