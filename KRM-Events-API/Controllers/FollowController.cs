using KRM_Events_API.Interfaces;
using KRM_Events_API.Mappers;
using KRM_Events_API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KRM_Events_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IFollowRepository _followRepository;
        private readonly UserManager<AppUser> _userManager;

        public FollowController(IFollowRepository followRepository, UserManager<AppUser> userManager)
        {
            _followRepository = followRepository;
            _userManager = userManager;
        }

        [Authorize(Roles = "Client")]
        [HttpPost("{AnnouncerId}")]
        public async Task<IActionResult> Follow(string AnnouncerId)
        {

            string clientId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await _followRepository.Follow(clientId,AnnouncerId);
            if (!result)
            {
                return BadRequest("already following");
            }

            return Ok(result);
        }

        [Authorize(Roles = "Client")]
        [HttpPost("Unfollow/{AnnouncerId}")]
        public async Task<IActionResult> UnFollow(string AnnouncerId)
        {

            string clientId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await _followRepository.UnFollow(clientId, AnnouncerId);
            if (!result)
            {
                return BadRequest("Already Not Following");
            }
            return Ok(result);
        }

        [Authorize(Roles = "Client")]
        [HttpPost("isFollowing/{AnnouncerId}")]
        public async Task<IActionResult> isFollowing(string AnnouncerId)
        {

            string clientId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await _followRepository.isFollowing(clientId, AnnouncerId);
            return Ok(result);
       
        }

        [HttpGet("{ClientId}/Following")]
        public async Task<IActionResult> GetListFollowing(string ClientId)
        {
            var FollowingList = await _followRepository.GetListOfFollowing(ClientId);
            if(FollowingList == null)
            {
                return BadRequest("user doesn't exist");
            }
            if (!FollowingList.Any())
            {
                return Ok(0);
            }
            return Ok(FollowingList.Select(x => x.ToUserDetailsFromUser()));
        }

        [HttpGet("{AnnouncerId}/Followers")]
        public async Task<IActionResult> GetListFollowers(string AnnouncerId)
        {
            var FollowersList = await _followRepository.GetListOfFollowers(AnnouncerId);
            if (FollowersList == null)
            {
                return BadRequest("user doesn't exist");
            }
            if (!FollowersList.Any())
            {
                return NoContent();
            }
            return Ok(FollowersList.Select(x => x.ToUserDetailsFromUser()));
        }


    }
}
