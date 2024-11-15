using KRM_Events_API.Data;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Model;
using Microsoft.EntityFrameworkCore;

namespace KRM_Events_API.Repositories
{
    public class TicketRepository : ITicketRepository
    {

        private readonly AppDbContext _dbContext;
        public TicketRepository(AppDbContext dbContext) 
        { 
           _dbContext = dbContext;
        
        }   
        public async Task<Ticket> AddTicket(Ticket ticket)
        {
            var EntityTicket = await  _dbContext.Tickets.AddAsync(ticket);
            

            await _dbContext.SaveChangesAsync();
            return ticket;
             
        }

        public async Task<List<Ticket>> GetTicketsByClient(string ClientId)
        {
            var tickets = _dbContext.Tickets.AsQueryable().Where(x=>x.ClientId.Equals(ClientId));
            var ticketsList = await tickets.ToListAsync();
            return tickets.ToList();
          
        }

        public async Task<List<Ticket>> GetTicketsByEvent(int id)
        {
            var tickets = _dbContext.Tickets.AsQueryable().Where(x => x.EventId == id);
            var ticketsList = await tickets.ToListAsync();
            return ticketsList;
        }
    }
}
