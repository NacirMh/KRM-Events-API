using KRM_Events_API.Dtos.Category;
using KRM_Events_API.Interfaces;
using KRM_Events_API.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KRM_Events_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoriesController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoryRepo.GetCategoryById(id);
            if (category == null) {
                return NotFound($"Category id : {id} not found");
            }
            var categoryDTO = category.ToCategoryDTO();
            return Ok(categoryDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryRepo.GetAll());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = categoryDto.ToCategoryFromCreateDto();
            var categoryCreated = await _categoryRepo.CreateCategory(category);
            return Ok(categoryCreated);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id , [FromBody] UpdateCategory updateCategory)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var categoryUpdate = await _categoryRepo.UpdateCategory(id, updateCategory);
            if (categoryUpdate == null) {
                return NotFound($"Category id : {id} not found");
            }
            return Ok(categoryUpdate);  
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(await _categoryRepo.DeleteCategory(id) == null)
            {
                return NotFound($"Category id : {id} not found");
            }

            await _categoryRepo.DeleteCategory(id);
            return Ok($"Category id {id} Deleted");    
        }

    }
}
