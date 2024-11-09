using KRM_Events_API.Model;

namespace KRM_Events_API.Interfaces
{
    public interface ITokenService
    {
        public  Task<string> CreateToken(AppUser user);
    }
}
