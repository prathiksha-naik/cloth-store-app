using ClothingStore.Application.Service;
using ClothingStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace ClothingStoreApplication.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ClothCategoryService _service;
        public CategoryController(ClothCategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetCategory")]
        public async Task<ActionResult<IEnumerable<ClothItem>>> GetClothCategory()
        {
            var ClothProducts = await _service.GetAllCategory();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(ClothProducts);
        }

        [HttpGet("GetCategoryById")]
        public async Task<ActionResult<ClothItem>> GetCategoryById(int categoryId)
        {
            var clothItem = _service.CategoryItemExist(categoryId);
            if (clothItem == false)
                return NotFound();
            var product = await _service.GetCategoryById(categoryId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(product);
        }

        [HttpGet("GetClothItemsByCategory")]
        public async Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAsync(int categoryId)
        {
            return await _service.GetClothItemsByCategoryAsync(categoryId);
        }

        [HttpGet("GetClothItemsByClothCategory")]
        public async Task<IEnumerable<ClothItem>> GetClothItemsByClothCategoryAsync(int clothCategoryId)
        {
            return await _service.GetClothItemsByClothCategoryAsync(clothCategoryId);
        }

        [HttpGet("GetClothItemsByCategoryAndClothCategory")]
        public async Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAndClothCategoryAsync(int categoryId, int clothCategoryId)
        {
            return await _service.GetClothItemsByCategoryAndClothCategoryAsync(categoryId, clothCategoryId);
        }

        [HttpGet("GetClothItemsByBrandNames")]
        public async Task<IEnumerable<ClothItem>> GetClothItemsByBrandNamesAsync([FromQuery] IEnumerable<string> brandNames)
        {
            return await _service.GetClothItemsByBrandNamesAsync(brandNames);
        }
    }
}
