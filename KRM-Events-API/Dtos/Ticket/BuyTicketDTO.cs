namespace KRM_Events_API.Dtos.Ticket
{
    public class BuyTicketDTO
    {

        public int EventId { get; set; } 

        public int NumberOfTickets { get; set; }

        public bool isUsedCouponCode { get; set; } = false;

        public int CouponCodeId { get; set; } = -1;
    }
}
