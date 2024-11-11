using KRM_Events_API.Data;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Mappers;
using KRM_Events_API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KRM_Events_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IEventRepository _eventRepository;
        private readonly UserManager<AppUser> _userManager;
        public FavoriteController(IFavoriteRepository favoriteRepository , IEventRepository eventRepository , UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _favoriteRepository = favoriteRepository;
            _eventRepository = eventRepository;
        }

        [Authorize(Roles = "Client")]
        [HttpPost("addToFavorite/{EventId}")] 
        public async Task<IActionResult> AddToFavorites(int EventId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) {

                return NotFound("User Not found");
            }
            if (! await _eventRepository.EventExists(EventId))
            {
                return NotFound("event not found");
            }
            var result = await  _favoriteRepository.AddToFavorites(user.Id,EventId);
            if (!result)
            {
                return Ok("already in favorites list");
            }
            return Ok(result);
        }

        [Authorize(Roles = "Client")]
        [HttpPost("RemoveFromFavorite/{EventId}")]
        public async Task<IActionResult> RemoveFromFavorites(int EventId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User Not found");
            }
            if (!await _eventRepository.EventExists(EventId))
            {
                return NotFound("event not found");
            }
            var result = await _favoriteRepository.RemoveFromFavorites(user.Id, EventId);
            if (!result)
            {
                return Ok("this event isn't in favorites list");
            }
            return Ok(result);
        }

        [Authorize(Roles = "Client")]
        [HttpGet("GetAllFavorites")]
        public async Task<IActionResult> GetAllFavorites()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User Not found");
            }
            var result = await _favoriteRepository.GetFavorites(user.Id);
            var resultDTO = result.Select(x=>x.ToEventDTO()).ToList();
            return Ok(resultDTO);
        }
    }
}
