using KRM_Events_API.Dtos.Ticket;
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
    public class TicketController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEventRepository _eventRepository;
        private readonly ITicketingService _ticketingService;

        public TicketController(UserManager<AppUser> userManager, IEventRepository eventRepository, ITicketingService ticketingService)
        {
            _userManager = userManager;
            _eventRepository = eventRepository;
            _ticketingService = ticketingService;


        }



        [Authorize(Roles = "Client")]
        [HttpPost]
        public async Task<IActionResult> BuyTicket(BuyTicketDTO buyTicketDto)
        {
            var client = await _userManager.GetUserAsync(User);
            if (client is null)
            {
                return BadRequest("invalid User");
            }
            var Event = await _eventRepository.GetByIdAsync(buyTicketDto.EventId);
            if (Event is null)
            {
                return NotFound($"event {buyTicketDto.EventId} not found");

            }

            if (Event.capacity < Event.Tickets.Count + buyTicketDto.NumberOfTickets)
            {
                return BadRequest(Event.capacity - Event.Tickets.Count);
            }
            
            

            List<Ticket> tickets = new List<Ticket>();
            for (int i = 0; i < buyTicketDto.NumberOfTickets; i++)
            {
                var ticket = await _ticketingService.BuyTicket(buyTicketDto.EventId, client.Id, buyTicketDto.CouponCodeId, buyTicketDto.isUsedCouponCode );
                if (ticket is null)
                {
                    return BadRequest("failed to buy ticket");
                }
                tickets.Add(ticket);
            }
            return Ok(tickets.Select(x=>x.ToTicketDto()));
        }
    }
}