using KRM_Events_API.Dtos.Event;
using KRM_Events_API.Model;

namespace KRM_Events_API.Mappers
{
    public static class EventMapper
    {
        public static EventDTO ToEventDTO(this Event model)
        {

            return new EventDTO
            {
                Price = model.Price,
                Name = model.Name,
                Description = model.Description,
                Adresse = model.Adresse,
                capacity = model.capacity,
                City = model.City,
                CategoryId = model.CategoryId,
                Date = model.Date,
                EventRequestId = model.EventRequestId,
                Id = model.Id,
                CouponCodes = model.CouponCodes.Select(x => x.ToCouponCodeDTO()).ToList(),
                Hashtags = model.EventHashtags.Select(x => x.Hashtag.ToHashtagDTO()).ToList(),
                Opinions = model.Opinions.Select(x=>x.ToOpinionDTO()).ToList(),
            };
        }

        public static Event ToEventFromDTO(this EventDTO eventDto)
        {
            return new Event
            {
                Adresse = eventDto.Adresse,
                capacity = eventDto.capacity,
                City = eventDto.City,
                CategoryId = eventDto.CategoryId,
                Date = eventDto.Date,
                EventRequestId = eventDto.EventRequestId,    
            };

        }
    }
}
