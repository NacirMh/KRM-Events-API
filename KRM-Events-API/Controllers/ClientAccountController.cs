using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KRM_Events_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAccountController : ControllerBase
    {
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp()
        {
            return Ok();
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn()
        {
            return Ok();
        }
    }
}
