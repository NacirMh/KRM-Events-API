using KRM_Events_API.Dtos.Event;
using KRM_Events_API.Model;

namespace KRM_Events_API.Mappers
{
    public static class EventRequestMapper
    {
        public static EventRequestDTO ToEventRequestDTO(this EventRequest eventRequest)
        {
            return new EventRequestDTO
            {
                AnnouncerId = eventRequest.AnnouncerId,
                Comment = eventRequest.Comment,
                Id = eventRequest.Id,
                EventDTO = eventRequest.Event.ToEventDTO(),
                Status = eventRequest.Status
            };
        }

        public static Event ToEventFromCreateEventDTO(this CreateEventDTO eventRqDto)
        {
            return new Event
            {
                Adresse = eventRqDto.Adresse,
                capacity = eventRqDto.capacity,
                CategoryId = eventRqDto.CategoryId,
                Date = eventRqDto.Date,
                City = eventRqDto.City,
                Description = eventRqDto.Description,
                Name = eventRqDto.Name,
                Price = eventRqDto.Price,
            };
        }
    }
}
