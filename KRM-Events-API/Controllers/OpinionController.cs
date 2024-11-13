using KRM_Events_API.Dtos.Opinion;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Mappers;
using KRM_Events_API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace KRM_Events_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionController : ControllerBase
    {
        private readonly IOpinionRepository _opinionRepository;
        private readonly UserManager<AppUser> _userManager;
        public OpinionController(IOpinionRepository opinionRepository, UserManager<AppUser> userManager)
        {
            _opinionRepository = opinionRepository;
            _userManager = userManager;
        }

        [HttpGet("byEvent")]
        public async Task<IActionResult> GetOpinionsByEvent(int Eventid)
        {
            var opinions = await  _opinionRepository.GetOpinionsByEvent(Eventid);
            if (opinions == null) {
                return NotFound("Event Not Found");
            }
            var opinionsDto = opinions.Select(x=>x.ToOpinionDTO()).ToList();  
            return Ok(opinionsDto);
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public async Task<IActionResult> CreateOpinion(CreateOpinionDTO opinionDto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("user not found");
            }
            var opinion =  opinionDto.ToOpinionFromCreateDto(user.Id);
            var addedOpinion = await _opinionRepository.CreateOpinion(opinion);
            if (addedOpinion == null) {
                return NotFound("event not found");
            }
            return Ok(addedOpinion.ToOpinionDTO()); 
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{OpinionId}")]
        public async Task<IActionResult> DeleteOpinion(int opinionId)
        {
            var opinion = await _opinionRepository.DeleteOpinion(opinionId);
            if (opinion is null)
            {
                return NotFound("opinion not found");
            }
            return Ok(opinion.ToOpinionDTO());
        }
    }
}
