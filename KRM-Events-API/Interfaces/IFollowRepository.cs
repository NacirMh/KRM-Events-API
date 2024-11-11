using KRM_Events_API.Model;

namespace KRM_Events_API.Interfaces
{
    public interface IFollowRepository
    {
        public Task<bool> Follow(string ClientId, string AnnouncerId);
        public Task<bool> UnFollow(string ClientId, string AnnouncerId);
        public Task<bool> isFollowing(string ClientId, string AnnouncerId);
        public Task<List<Client>> GetListOfFollowers(string AnnouncerId);
        public Task<List<Announcer>> GetListOfFollowing(string ClientId);



    }
}
