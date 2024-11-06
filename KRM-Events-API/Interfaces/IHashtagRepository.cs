using KRM_Events_API.Dtos.Hashtag;
using KRM_Events_API.Model;

namespace KRM_Events_API.Interfaces
{
    public interface IHashtagRepository
    {
        public Task<Hashtag?> GetById(int id);

        public Task<List<Hashtag>> GetAll();
        public Task<Hashtag> CreateHashtag(Hashtag hashtag);

        public Task<Hashtag?> DeleteHashtag(int id);

        public Task<Hashtag?> UpdateHashtag(int id ,UpdateHashtagDTO updatedto);
 

    }
}
