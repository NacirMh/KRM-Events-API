using KRM_Events_API.Data;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Model;
using Microsoft.EntityFrameworkCore;

namespace KRM_Events_API.Repositories
{
    public class OpinionRepository : IOpinionRepository
    {
        private readonly AppDbContext _dbContext;
        public OpinionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Opinion> CreateOpinion(Opinion opinion)
        {
            var Event = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == opinion.EventId);
            if (Event == null) {
                return null;
            }
            await _dbContext.Events.AddAsync(Event);
            await _dbContext.SaveChangesAsync();
            return opinion;
        }

        public async Task<Opinion> DeleteOpinion(Opinion opinion)
        {
            throw new NotImplementedException();
        }

        public Task<List<Opinion>> GetOpinionsByEvent(string EventId)
        {
            throw new NotImplementedException();
        }

        public Task<Opinion> UpdateOpinion(Opinion opinion)
        {
            throw new NotImplementedException();
        }
    }
}
