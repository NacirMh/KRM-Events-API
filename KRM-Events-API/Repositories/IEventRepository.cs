using KRM_Events_API.Data;
using KRM_Events_API.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            if (Event == null) {
                return false;
            }
            return true;
        }
    }
}
