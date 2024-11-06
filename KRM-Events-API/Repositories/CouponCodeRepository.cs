using KRM_Events_API.Data;
using KRM_Events_API.Dtos.CouponCode;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Model;
using Microsoft.EntityFrameworkCore;

namespace KRM_Events_API.Repositories
{
    public class CouponCodeRepository : ICouponCodeRepository
    {
        private readonly AppDbContext _context;
        public CouponCodeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CouponCode?> DeleteCouponCode(int id)
        {
            var couponCode = await _context.CouponCodes.FirstOrDefaultAsync(x => x.Id == id);
            if (couponCode == null)
            {
                return null;
            }
            _context.CouponCodes.Remove(couponCode);
            await _context.SaveChangesAsync();
            return couponCode;
        }

        public async Task<CouponCode> GenerateCouponCode(CouponCode couponCode)
        {
            await _context.CouponCodes.AddAsync(couponCode);
            await _context.SaveChangesAsync();
            return couponCode;
        }

        public async Task<List<CouponCode>> GetCouponCodesByEvent(int EventId)
        {
            var couponCodes = await _context.CouponCodes.Where(x => x.EventId == EventId).ToListAsync();
            return couponCodes;
        }


        public async Task<CouponCode> UseCouponCode(int couponCodeId)
        {
            var ExistingCouponCode = await _context.CouponCodes.FirstOrDefaultAsync(x => x.Id == couponCodeId);
            if (ExistingCouponCode == null)
            {
                return null;
            }
            ExistingCouponCode.Quantity--;
            return ExistingCouponCode;
        }

        public async Task<bool> verifyCouponCode(int EventId, string couponCodeCode)
        {
            var CouponCode = await _context.CouponCodes.FirstOrDefaultAsync(x => x.EventId == EventId);

            if (CouponCode != null && CouponCode.Code.Equals(couponCodeCode))
            {
                return true;
            }
            return false;
        }
    }
}
