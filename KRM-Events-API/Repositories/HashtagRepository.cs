using KRM_Events_API.Data;
using KRM_Events_API.Dtos.Hashtag;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Model;
using Microsoft.EntityFrameworkCore;

namespace KRM_Events_API.Repositories
{
    public class HashtagRepository : IHashtagRepository
    {
        private readonly AppDbContext _context;
        public HashtagRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hashtag>> GetAll() 
        {
            var hashtags = await _context.Hashtags.ToListAsync();
            return hashtags;
        }

        public async Task<Hashtag?> GetById(int id)
        {
            var hashtag= await _context.Hashtags.FirstOrDefaultAsync(x=>x.Id == id);
            if (hashtag == null) {
                return null;
            }
            return hashtag;
        }

        public async Task<Hashtag> CreateHashtag(Hashtag hashtag)
        {
            await _context.Hashtags.AddAsync(hashtag);
            await _context.SaveChangesAsync();
            return hashtag;
        }

        public async Task<Hashtag?> DeleteHashtag(int id)
        {
            var Hashtag = await _context.Hashtags.FirstOrDefaultAsync(y=>y.Id == id);
            if (Hashtag == null)
            {
                return null;
            }
            _context.Hashtags.Remove(Hashtag);
            await _context.SaveChangesAsync();
            return Hashtag;
        }

        public async Task<Hashtag?> UpdateHashtag(int id, UpdateHashtagDTO updatedto)
        {
            var existingHashtag = await _context.Hashtags.FirstOrDefaultAsync(y => y.Id == id);
            if (existingHashtag == null) {
                return null;
            }
            existingHashtag.HashTagName = updatedto.HashTagName;    
            existingHashtag.HashTagDescription = updatedto.HashTagDescription;
            await _context.SaveChangesAsync();
            return existingHashtag;
        }
    }
}
