using KRM_Events_API.Dtos.Hashtag;
using KRM_Events_API.Model;

namespace KRM_Events_API.Mappers
{
    public static class HashtagMapper
    {
        public static HashtagDTO ToHashtagDTO(this Hashtag hashtag)
        {
            return new HashtagDTO
            {
                HashTagName = hashtag.HashTagName,
                HashTagDescription = hashtag.HashTagDescription,
                Id = hashtag.Id
            };
        }
        public static Hashtag ToHashtagFromCreateDto(this CreateHashtagDTO hashtagDTO) {
            return new Hashtag
            {
                    HashTagName = hashtagDTO.HashTagName, 
                    HashTagDescription = hashtagDTO.HashTagDescription
            };
        }
    }
}
