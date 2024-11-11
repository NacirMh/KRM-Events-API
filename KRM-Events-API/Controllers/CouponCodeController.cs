using KRM_Events_API.Dtos.CouponCode;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KRM_Events_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponCodeController : ControllerBase
    {
        private readonly ICouponCodeRepository _couponCodeRepo;
        private readonly IEventRepository _eventRepo;

        public CouponCodeController(ICouponCodeRepository couponCodeRepo, IEventRepository EventRepo)
        {
            _couponCodeRepo = couponCodeRepo;
            _eventRepo = EventRepo;
        }


        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetCouponCodesByEvent(int eventId)
        {
            if (!await _eventRepo.EventExists(eventId))
            {
                return NotFound($"Event Id : {eventId} doesn't  exists");
            }
            var couponCodes = _couponCodeRepo.GetCouponCodesByEvent(eventId).Result.AsQueryable().Select(x => x.ToCouponCodeDTO());
            return Ok(couponCodes);
        }

        [Authorize(Roles = "Announcer")]
        [HttpPost("{eventId}")]
        public async Task<IActionResult> GenerateCouponCode(int eventId, [FromBody] CreateCouponCodeDTO createCodeDto)
        {
            if (!await _eventRepo.EventExists(eventId))
            {
                return NotFound($"Event id : {eventId} doesn't exist");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var couponCode = _couponCodeRepo.GenerateCouponCode(createCodeDto.ToCouponCode(eventId)).Result.ToCouponCodeDTO();
            return Ok(couponCode);
        }

        //[HttpPost("{EventId}")]
        //public async Task<IActionResult> UseCouponCode(int EventId, [FromBody] string Code)
        //{
        //    if (!await _eventRepo.EventExists(EventId))
        //    {
        //        return NotFound($"event id : {EventId} doesn't exist")
        //    }
        //    if (!await _couponCodeRepo.verifyCouponCode(EventId, Code))
        //    {
        //        return BadRequest("coupon code isn't Valid");
        //    }
        //   // await _couponCodeRepo.UseCouponCode();
        //    return Ok();
        //}


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCouponCode(int id)
        {
            var couponCode = await _couponCodeRepo.DeleteCouponCode(id);
            if (couponCode == null)
            {
                return NotFound($"CouponCode id : {id} doesn't exist");
            }
            return Ok(couponCode);
        }
    }
}
