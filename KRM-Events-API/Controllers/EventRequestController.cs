using KRM_Events_API.Dtos.Event;
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
    public class EventRequestController : ControllerBase
    {
        private readonly IEventRequestRepository _eventRequestRepository;
        private readonly UserManager<AppUser> _userManager; 
        public EventRequestController(IEventRequestRepository eventRequestRepository , UserManager<AppUser> userManager)
        {
            _eventRequestRepository = eventRequestRepository;
            _userManager = userManager;
        }

        [Authorize(Roles ="Admin,Announcer")]
        [HttpGet()]
        [Route("AllRequests")]
        public async Task<IActionResult> GetAllRequests([FromQuery] string? AnnouncerId)
        {
            var eventRequests = await _eventRequestRepository.GetAllRequests();
            var eventRequestsDto = eventRequests.Select(x => x.ToEventRequestDTO()).ToList();
            if (AnnouncerId != null)
            {
                eventRequestsDto = eventRequestsDto.Where(x => x.AnnouncerId.Equals(AnnouncerId)).ToList();
            }
            return Ok(eventRequestsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var EventRequest = await _eventRequestRepository.GetRequestById(id);
            if (EventRequest is null)
            {
                return NotFound($"event id {id} not found");
            }
            return Ok(EventRequest.ToEventRequestDTO());
        }

        [Authorize(Roles = "Admin,Announcer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var eventRequest = await _eventRequestRepository.DeleteRequest(id);
            if (eventRequest is null)
            {
                return NotFound($"event id {id} not found");
            }
            return Ok(eventRequest);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("HandleRequest/{id}")]
        public async Task<IActionResult> HandleRequest([FromRoute] int id, [FromBody] AcceptEventRequestDTO accept)
        {
            var handlingRequestResult = await _eventRequestRepository.AcceptRequest(id, accept);
            if (handlingRequestResult is null)
            {
                return NotFound("Event Request NotFound");
            }
            return Ok(handlingRequestResult);
        }

        //[Authorize(Roles = "Announcer")]
        [HttpPost("MakeRequest")]
        public async Task<IActionResult> MakeRequest([FromBody] CreateEventDTO CreateEventRqDto)
        {
            
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                return NotFound("User Not found");
            }
            var CreatedEventRequest = await _eventRequestRepository.MakeRequest(user.Id, CreateEventRqDto);
            return Ok(CreatedEventRequest.ToEventRequestDTO());
        }

        

    }
}
