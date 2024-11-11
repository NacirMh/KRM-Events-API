using KRM_Events_API.Data;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Model;
using Microsoft.EntityFrameworkCore;

namespace KRM_Events_API.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _dbContext;

        public FavoriteRepository(AppDbContext dbContext)
        {
             _dbContext = dbContext;
        }
        public async Task<bool> AddToFavorites(string ClientId, int EventId)
        {
            var AlreadyFavorite = await  _dbContext.Favorites.FirstOrDefaultAsync(x=> x.EventId == EventId && x.ClientId == ClientId);
            if (AlreadyFavorite is not null)
            {
               return false;
            }


            var Favorite = new Favorite { ClientId = ClientId, EventId = EventId };
            await _dbContext.Favorites.AddAsync(Favorite);
            await _dbContext.SaveChangesAsync();  
            return true;
        }


        public async Task<List<Event>> GetFavorites(string ClientId)
        {
             var Favorites = await _dbContext.Favorites.Where(x=>x.ClientId == ClientId).ToListAsync();
             var events = new List<Event>();    
             foreach (var favorite in Favorites)
             {
                if (favorite.Event is not null)
                {
                    events.Add(favorite.Event);
                }                
             }

             return events;
        }

        public async Task<bool> RemoveFromFavorites(string ClientId, int EventId)
        {
            var Favorite = await _dbContext.Favorites.FirstOrDefaultAsync(x => x.EventId == EventId && x.ClientId == ClientId);
            if(Favorite is null)
            {
                return false;
            }
            _dbContext.Favorites.Remove(Favorite);
            await _dbContext.SaveChangesAsync() ;

            return true;
        }
    }
}
