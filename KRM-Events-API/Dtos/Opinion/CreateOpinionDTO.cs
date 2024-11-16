using KRM_Events_API.Dtos.Account;
using KRM_Events_API.Dtos.Event;
using System.ComponentModel.DataAnnotations;

namespace KRM_Events_API.Dtos.Opinion
{
    public class CreateOpinionDTO
    {

        

        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public int EventId { get; set; }
    }
}
