using KRM_Events_API.Dtos.CouponCode;
using KRM_Events_API.Model;

namespace KRM_Events_API.Interfaces
{
    public interface ICouponCodeRepository
    {
        public Task<CouponCode> GenerateCouponCode(CouponCode couponCode);

        public Task<List<CouponCode>> GetCouponCodesByEvent(int EventId);

        public Task<CouponCode?> DeleteCouponCode(int id);

        public Task<CouponCode> UseCouponCode(int id);

        public Task <bool> verifyCouponCode(int EventId , string couponCodeCode);

    }
}
