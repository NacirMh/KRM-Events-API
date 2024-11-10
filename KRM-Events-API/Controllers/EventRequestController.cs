using KRM_Events_API.Interfaces;
using KRM_Events_API.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KRM_Events_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRequestController : ControllerBase
    {
        private readonly IEventRequestRepository _eventRequestRepository;
        public EventRequestController(IEventRequestRepository eventRequestRepository)
        {
            _eventRequestRepository = eventRequestRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequests() {
             var eventRequests = await _eventRequestRepository.GetAllRequests();
             var eventRequestsDto =  eventRequests.Select(x=>x.ToEventRequestDTO()).ToList();   
             return Ok(eventRequestsDto);
        }    
    }
}
