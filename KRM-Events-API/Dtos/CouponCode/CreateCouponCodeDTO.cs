using System.ComponentModel.DataAnnotations;

namespace KRM_Events_API.Dtos.CouponCode
{
    public class CreateCouponCodeDTO
    {

        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]

        [Range(0, 100)]
        public int Discount { get; set; }

        [Required]
        public DateTime DateOfRedemption { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
