using KRM_Events_API.Dtos.Event;
using KRM_Events_API.Helpers;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KRM_Events_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet("GetEvents")]
        public async Task<IActionResult> GetEvents([FromQuery]EventQueryObject eventQuery)
        {
            var events = await _eventRepository.GetAllAcceptedEvents(eventQuery);
            var eventsDto = events.Select(x=> x.ToEventDTO()).ToList();
            return Ok(eventsDto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById([FromRoute] int id)
        {
            var eventt = await _eventRepository.GetByIdAsync(id);
            if (eventt is null) {
                 return NotFound($"Invalid event Id");
            }
            var eventDto = eventt.ToEventDTO();
            return Ok(eventDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            var Event = await _eventRepository.DeleteEvent(id);
            if (Event is null) {
                return NotFound($"event id {id} not found");
            }
            return Ok(Event);   
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent([FromRoute]int id , [FromBody]UpdateEventDTO eventDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }   
            var EventUpdated = await _eventRepository.UpdateEvent(id, eventDto);
            if (EventUpdated is null) {
              return NotFound("event id {id} Not Found");
            }
            return Ok(EventUpdated);
        }

    }
}
