using KRM_Events_API.Dtos.Hashtag;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace KRM_Events_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashtagController : ControllerBase
    {
        private readonly IHashtagRepository _hashtagRepo;
        public HashtagController(IHashtagRepository hashtagRepo)
        {
            _hashtagRepo = hashtagRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var hashtag = await _hashtagRepo.GetById(id);
            if (hashtag == null)
            {
                return NotFound($"Hashtag id : {id} not found");
            }
            var hashtagDTO = hashtag.ToHashtagDTO();
            return Ok(hashtagDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hashtags = await _hashtagRepo.GetAll();
            var hashtagsDto = hashtags.Select(x => x.ToHashtagDTO()).ToList();
            return Ok(hashtagsDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHashtag(int id)
        {
            var hashtag = await _hashtagRepo.DeleteHashtag(id);
            if (hashtag == null)
            {
                return NotFound($"Hashtag id : {id} not found");
            }
            return Ok(hashtag);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHashtag([FromBody] CreateHashtagDTO createDTO)
        {
                var hashtag = createDTO.ToHashtagFromCreateDto();
                var createdHashtag = await _hashtagRepo.CreateHashtag(hashtag);
                return Ok(createdHashtag);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHashtag([FromRoute] int id, [FromBody] UpdateHashtagDTO updatehashtag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var hashtagUpdate = await _hashtagRepo.UpdateHashtag(id, updatehashtag);
            if (hashtagUpdate == null)
            {
                return NotFound($"Hashtag id : {id} not found");
            }
            return Ok(hashtagUpdate);

        }




    }
}
