using KRM_Events_API.Dtos.Opinion;
using KRM_Events_API.Model;

namespace KRM_Events_API.Mappers
{
    public static class OpinionMapper
    {

        public static OpinionDTO ToOpinionDTO(this Opinion opinion)
        {
            return new OpinionDTO
            {
                ClientDetails = opinion.Client.ToUserDetailsFromUser(),
                Content = opinion.Content,
                Id = opinion.Id,
                Event = opinion.Event.ToEventDTO(),
                CreatedAt = opinion.CreatedAt,

            };
        }

        public static Opinion ToOpinionFromCreateDto(this CreateOpinionDTO opinionDto, string userId)
        {
            return new Opinion
            {
                ClientId = userId,
                Content = opinionDto.Content,
                EventId = opinionDto.EventId,
            };
        }
    }
}
