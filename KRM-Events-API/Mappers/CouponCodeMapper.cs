using KRM_Events_API.Dtos.CouponCode;
using KRM_Events_API.Model;

namespace KRM_Events_API.Mappers
{
    public static class CouponCodeMapper
    {

        public static CouponCode ToCouponCode(this CreateCouponCodeDTO dto, int EventId)
        {
            return new CouponCode
            {
                 Code = dto.Code,
                 DateOfRedemption = dto.DateOfRedemption,
                 Discount = dto.Discount,
                 EventId = EventId,
                 Quantity = dto.Quantity,
                 
            };
        }
        public static CouponCodeDTO ToCouponCodeDTO(this CouponCode couponCode) {

            return new CouponCodeDTO
            {
                Id = couponCode.Id,
                Code = couponCode.Code,
                CreatedAt = couponCode.CreatedAt,
                DateOfRedemption = couponCode.DateOfRedemption,
                Discount = couponCode.Discount,
                EventId = couponCode.EventId,
            };
        }
    }
}
