﻿using KRM_Events_API.Dtos.Ticket;
using KRM_Events_API.Model;

namespace KRM_Events_API.Interfaces
{
    public interface ITicketingService
    {

          public Task<Ticket> BuyTicket(int eventID, string ClientId,int CouponCodeId, bool IsUsedCouponCode);
          
          
    }
}