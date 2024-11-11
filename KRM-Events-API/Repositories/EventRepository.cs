using KRM_Events_API.Data;
using KRM_Events_API.Dtos.Event;
using KRM_Events_API.Helpers;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Model;
using KRM_Events_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace KRM_Events_API.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _DbContext;

        public EventRepository(AppDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<bool> EventExists(int id)
        {
            var Event = await _DbContext.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (Event == null)
            {
                return false;
            }
            return true;
        }

        public Task<List<Event>> GetAllAcceptedEvents(EventQueryObject query)
        {
            var events = _DbContext.Events.Include(x => x.EventHashtags).Include(x => x.CouponCodes).AsQueryable();
            events = events.Where(x => x.EventRequest.Status);
            if (!string.IsNullOrWhiteSpace(query.HashtagName))
            {
                var hashtag = _DbContext.Hashtags.FirstOrDefault(x => x.HashTagName.Contains(query.HashtagName));
                if (hashtag != null)
                {
                    events = events.Where(x => hashtag.HashTagName.Contains(query.HashtagName));
                }
            }

            if (!string.IsNullOrWhiteSpace(query.CategoryName))
            {
                var category = _DbContext.Categories.FirstOrDefault(x => x.CategoryName.Contains(query.CategoryName));
                if (category != null)
                {
                    events = events.Where(x => category.CategoryName.Contains(query.CategoryName));
                }
            }

            if (!string.IsNullOrWhiteSpace(query.City))
            {
                events = events.Where(x => x.City.Contains(query.City));
            }

            if (!string.IsNullOrWhiteSpace(query.SortedBy))
            {
                if (query.SortedBy.Equals("price", StringComparison.OrdinalIgnoreCase))
                {
                    events = query.IsDesc ? events.OrderByDescending(x => x.Price) : events.OrderBy(x => x.Price);
                }
                if (query.SortedBy.Equals("capacity", StringComparison.OrdinalIgnoreCase))
                {
                    events = query.IsDesc ? events.OrderByDescending(x => x.Price) : events.OrderBy(x => x.Price);
                }
            }

            return events.ToListAsync();

        }

        public async Task<Event> GetByIdAsync(int id)
        {
            var eventt = await _DbContext.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (eventt is null)
            {
                return null;
            }
            return eventt;
        }

        public async Task<Event> DeleteEvent(int id)
        {
            var Event = await _DbContext.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (Event is null)
            {
                return null;
            }
            _DbContext.Events.Remove(Event);
            await _DbContext.SaveChangesAsync();
            return Event;
        }

        public async Task<Event> UpdateEvent(int id, UpdateEventDTO updateEventDTO)
        {
            var Event = await _DbContext.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (Event is null)
            {
                return null;
            }
            Event.capacity = updateEventDTO.capacity;
            Event.Adresse = updateEventDTO.Adresse;
            Event.Price = updateEventDTO.Price;
            Event.CategoryId = updateEventDTO.CategoryId;
            Event.City = updateEventDTO.City;
            Event.Description = updateEventDTO.Description;
            Event.Name = updateEventDTO.Name;
            Event.Date = updateEventDTO.Date;
            if (updateEventDTO.HashtagsIds.Any())
            {
                foreach (int HashtagId in updateEventDTO.HashtagsIds)
                {
                    if (await _DbContext.Hashtags.FirstOrDefaultAsync(x => x.Id == HashtagId) != null) { 
                          var hashtagEvent = new EventHashtag { EventId = id , HashtagId = HashtagId};
                          Event.EventHashtags.Add(hashtagEvent);
                    }
                }
            }
            await _DbContext.SaveChangesAsync();
            return Event;
        }
    }
}
