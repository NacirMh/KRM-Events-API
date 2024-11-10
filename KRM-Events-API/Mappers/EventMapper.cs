using KRM_Events_API.Dtos.Event;

namespace KRM_Events_API.Mappers
{
    public static class EventMapper
    {
        public static EventDTO ToEventDTO(this Model.Event model)
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
                 CouponCodes = model.CouponCodes.Select(x=>x.ToCouponCodeDTO()).ToList(),
                 Hashtags = model.EventHashtags.Select(x => x.Hashtag.ToHashtagDTO()).ToList(),
            };
        }
    }
}
