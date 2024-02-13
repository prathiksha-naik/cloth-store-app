using ClothingStore.Application.Service;
using ClothingStore.Domain.Entities;
using ClothStoreApplication.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClothCategoriesController : ControllerBase
    {
        private readonly ClothCategoryService _clothCategoryService;

        public ClothCategoriesController(ClothCategoryService clothCategoryService)
        {
            _clothCategoryService = clothCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothCategoryDto>>> GetAllClothCategories()
        {
            var clothCategories = await _clothCategoryService.GetAllClothCategories();
            return Ok(clothCategories);
        }
        [HttpGet("GetClothItemsByClothCategory")]
        public async Task<IEnumerable<ClothItem>> GetClothItemsByClothCategoryAsync(int clothCategoryId)
        {
            return await _clothCategoryService.GetClothItemsByClothCategoryAsync(clothCategoryId);
        }

        [HttpGet("GetClothItemsByCategoryAndClothCategory")]
        public async Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAndClothCategoryAsync(int categoryId, int clothCategoryId)
        {
            return await _clothCategoryService.GetClothItemsByCategoryAndClothCategoryAsync(categoryId, clothCategoryId);
        }

        [HttpPost]
        public async Task<IActionResult> AddClothCategory([FromBody] ClothCategoryDto clothCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clothCategoryService.AddClothCategory(clothCategoryDto);
            return CreatedAtAction(nameof(AddClothCategory), clothCategoryDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClothCategory(int id, [FromBody] ClothCategoryDto clothCategoryDto)
        {
            if (id != clothCategoryDto.ClothCategoryId)
            {
                return BadRequest();
            }

            await _clothCategoryService.UpdateClothCategory(clothCategoryDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothCategory(int id)
        {
            await _clothCategoryService.DeleteClothCategory(id);
            return NoContent();
        }
    }
}