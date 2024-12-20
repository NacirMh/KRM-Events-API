﻿using KRM_Events_API.Data;
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
            _dbContext.Opinions.Add(opinion);   
            await _dbContext.SaveChangesAsync();
            return opinion;
        }

        public async Task<Opinion> DeleteOpinion(int id)
        {
            var opinion = await _dbContext.Opinions.FirstOrDefaultAsync(x => x.Id == id);
            if (opinion is null)
            {
                return null;
            }
            _dbContext.Opinions.Remove(opinion);
            await _dbContext.SaveChangesAsync();    
            return opinion;
        }

        

        public async Task<List<Opinion>> GetOpinionsByEvent(int EventId)
        {
            var Event = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == EventId);
            if(Event == null)
            {
                return null;
            }
            var opinions = await _dbContext.Opinions.ToListAsync();
            var opinionsByEvent = opinions.Where(x => x.EventId == EventId).ToList();  
            return opinionsByEvent;

        }

        public Task<Opinion> UpdateOpinion(Opinion opinion)
        {
            throw new NotImplementedException();
        }
    }
}
