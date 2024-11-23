using KRM_Events_API.Interfaces;
using KRM_Events_API.Model;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;

namespace KRM_Events_API.Services
{
    public class TicketingService : ITicketingService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ICouponCodeRepository _couponCodeRepository;
        private readonly IEventRepository _eventRepository;

        public TicketingService(ITicketRepository ticketRepository, ICouponCodeRepository couponCodeRepository, IEventRepository eventRepository)
        {
            _ticketRepository = ticketRepository;
            _couponCodeRepository = couponCodeRepository;
            _eventRepository = eventRepository;
        }
        public async Task<Ticket> BuyTicket(int EventId, string ClientId, int CouponCodeId, bool IsUsedCouponCode)
        {

            
            var Event = await _eventRepository.GetByIdAsync(EventId);
            if(Event == null)
            {
                return null;
            }
            var couponCode = Event.CouponCodes.FirstOrDefault(x => x.Id == CouponCodeId);
            Ticket ticket = new Ticket()
            {
                ClientId = ClientId,
                EventId = EventId,
                IsUsedCouponCode = IsUsedCouponCode,
                Price = IsUsedCouponCode && couponCode != null ? Event.Price - couponCode.Discount : Event.Price,
            };
          

           

            var ticketAdded = await _ticketRepository.AddTicket(ticket);
            if (couponCode != null && couponCode.Quantity > 0)
            {
                await _couponCodeRepository.UseCouponCode(CouponCodeId);
            }
            

            return ticketAdded;
        }
        public async Task<List<Ticket>> GetTicketsByClient(string ClientId)
        {
            var tickets = await _ticketRepository.GetTicketsByClient(ClientId);
            return tickets;

        }

        public async Task<List<Ticket>> GetTicketsByEvent(int EventId)
        {
            var tickets = await _ticketRepository.GetTicketsByEvent(EventId);
            return tickets;
        }
    }
}
