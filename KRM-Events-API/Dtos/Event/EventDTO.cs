using KRM_Events_API.Model;
using KRM_Events_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KRM_Events_API.Dtos.CouponCode;
using KRM_Events_API.Dtos.Hashtag;
using KRM_Events_API.Dtos.Opinion;

namespace KRM_Events_API.Dtos.Event
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string City { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int capacity { get; set; }

        public int CategoryId { get; set; }

        public int EventRequestId { get; set; }

        public List<CouponCodeDTO> CouponCodes { get; set; } = new List<CouponCodeDTO>();

        //public List<Favorite> favorites { get; set; } = new List<Favorite>();

        public List<OpinionDTO> Opinions { get; set; } = new List<OpinionDTO>();

        //public List<Ticket> Tickets { get; set; } = new List<Ticket>();

        public List<HashtagDTO> Hashtags { get; set; } = new List<HashtagDTO>();
    }
}
