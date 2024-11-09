using System.Security.Claims;

namespace KRM_Events_API.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.Claims.SingleOrDefault(x => x.Type.Equals(ClaimTypes.Name)).Value;
        }
    }
}
