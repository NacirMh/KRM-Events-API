using KRM_Events_API.Dtos.Account;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Mappers;
using KRM_Events_API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Rewrite;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static Azure.Core.HttpHeader;

namespace KRM_Events_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly SignInManager<AppUser> _signInManager;
        public readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> um, RoleManager<IdentityRole> rm, SignInManager<AppUser> sm, ITokenService tokenService)
        {
            _userManager = um;
            _roleManager = rm;
            _signInManager = sm;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                AppUser? appUser = null;

                if (registerDTO.Role.ToLower().Equals("admin"))
                {
                    appUser = registerDTO.ToAdminFromRegisterDTO();
                }

                else if (registerDTO.Role.ToLower().Equals("announcer"))
                {
                    appUser = registerDTO.ToAnnouncerFromRegisterDTO();
                }
                else
                {
                    appUser = registerDTO.ToClientFromRegisterDTO();
                }
                if (appUser != null)
                {
                    var result = await _userManager.CreateAsync(appUser, registerDTO.Password);
                    if (!result.Succeeded)
                    {
                        return BadRequest(result.Errors);
                    }
                }


                IdentityResult? roleResult = null;
                if (appUser is Admin)
                {
                    roleResult = await _userManager.AddToRoleAsync(appUser, "ADMIN");
                }
                else if (appUser is Announcer)
                {
                    roleResult = await _userManager.AddToRoleAsync(appUser, "ANNOUNCER");
                }
                else
                {
                    roleResult = await _userManager.AddToRoleAsync(appUser, "CLIENT");
                }

                if (roleResult.Succeeded)
                {
                    return Ok(new AuthResponseDTO
                    {
                        isSuccess = true,
                        Message = "Account created successfully",
                        Token = _tokenService.CreateToken(appUser).Result

                    });

                }
                else
                {
                    return BadRequest(roleResult.Errors);
                }


            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                return Unauthorized(new AuthResponseDTO
                {
                    isSuccess = false,
                    Message = $"User with email{loginDTO.Email} not found"
                });
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.password, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new AuthResponseDTO
                {
                    isSuccess = false,
                    Message = "Invalid Password"
                });
            }
            return Ok(new AuthResponseDTO
            {
                isSuccess = true,
                Message = "User Logged in",
                Token = _tokenService.CreateToken(user).Result
            });
        }

        [HttpGet("Details")]
        public async Task<IActionResult> GetUserDetails()
        {
             var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _userManager.FindByIdAsync(userId!);

            if (user is null)
            {
                return NotFound(new AuthResponseDTO
                {
                    isSuccess = false,
                    Message = "user not found"
                });
            }
            var userDetails = user.ToUserDetailsFromUser();
            return Ok(userDetails);
        }
    }

}
