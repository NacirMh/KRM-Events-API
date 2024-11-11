using KRM_Events_API.Model;

namespace KRM_Events_API.Interfaces
{
    public interface IFavoriteRepository
    {
        public Task<bool> AddToFavorites(string ClientId, int EventId);
        public Task<bool> RemoveFromFavorites(string CleintId, int EventId);
        public Task<List<Event>> GetFavorites(string ClientId);
        
        
    }
}
