using KRM_Events_API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KRM_Events_API.Dtos.CouponCode
{
    public class CouponCodeDTO
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]

        [Range(0, 100)]
        public int Discount { get; set; }

        [Required]
        public DateTime DateOfRedemption { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

    }
}
