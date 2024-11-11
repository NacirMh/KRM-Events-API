using KRM_Events_API.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRM_Events_API.Dtos.Event
{
    public class CreateEventDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string City { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int capacity { get; set; }
        public int CategoryId { get; set; }
        public List<int> HashtagsIds { get; set; } = new List<int>();
    }
}
