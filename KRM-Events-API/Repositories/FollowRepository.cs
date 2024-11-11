using KRM_Events_API.Data;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KRM_Events_API.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _DbContext;
        public FollowRepository(UserManager<AppUser> userManager, AppDbContext appDbContext)
        {
            _userManager = userManager; 
            _DbContext = appDbContext;

        }
        public async Task<bool> Follow(string ClientId, string AnnouncerId)
        {
            var Client = await _userManager.FindByIdAsync(ClientId);
            var Announcer = await _userManager.FindByIdAsync(AnnouncerId);
            if (Client == null || Announcer == null) {
                return false;
            }
            var Follow = new ClientAnnouncer
            {
                ClientId = ClientId,
                AnnouncerId = AnnouncerId
            };

            var isFollowing =  await _DbContext.CLientAnnouncers.FirstOrDefaultAsync(x=> x.ClientId == ClientId && x.AnnouncerId == AnnouncerId);
            if (isFollowing == null)
            {
                await _DbContext.CLientAnnouncers.AddAsync(Follow);
                await _DbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UnFollow(string ClientId, string AnnouncerId)
        {
            var Client = await _userManager.FindByIdAsync(ClientId);
            var Announcer = await _userManager.FindByIdAsync(AnnouncerId);
            if (Client == null || Announcer == null)
            {
                return false;
            }
            var isFollowing = await _DbContext.CLientAnnouncers.FirstOrDefaultAsync(x => x.ClientId == ClientId && x.AnnouncerId == AnnouncerId);
            if (isFollowing != null)
            {
                 _DbContext.CLientAnnouncers.Remove(isFollowing);
                await _DbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Client>> GetListOfFollowers(string AnnouncerId)
        {
            var Announcer = await _userManager.FindByIdAsync(AnnouncerId);
            if (Announcer == null)
            {
                return null;
            }
            var ClientAnnouncers = await _DbContext.CLientAnnouncers.Where(x => x.AnnouncerId == Announcer.Id).ToListAsync();
            var FollowersList = new List<Client>();
            foreach (var follow in ClientAnnouncers)
            {
                if (follow.Client != null)
                {
                    FollowersList.Add(follow.Client);
                }
            }
            return FollowersList;

        }

        public async Task<List<Announcer>> GetListOfFollowing(string ClientId)
        {
            var Client = await _userManager.FindByIdAsync(ClientId);
            if (Client == null)
            {
                return null;
            }
            var ClientAnnouncers = await _DbContext.CLientAnnouncers.Where(x=>x.ClientId == Client.Id).ToListAsync();
            var FollowingList = new List<Announcer>();
            foreach (var follow in ClientAnnouncers)
            {
                if(follow.Announcer != null)
                {
                    FollowingList.Add(follow.Announcer);
                }
            }
            return FollowingList;

        }

        public async Task<bool> isFollowing(string ClientId, string AnnouncerId)
        {
            var Client = await _userManager.FindByIdAsync(ClientId);
            var Announcer = await _userManager.FindByIdAsync(AnnouncerId);
            if (Client == null || Announcer == null)
            {
                return false;
            }
            var isFollowing = await _DbContext.CLientAnnouncers.FirstOrDefaultAsync(x => x.ClientId == ClientId && x.AnnouncerId == AnnouncerId);
            if (isFollowing != null)
            {
                return true;
            }
            return false;

        }

        
    }
}
