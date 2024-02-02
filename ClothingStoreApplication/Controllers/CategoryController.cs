using ClothingStore.Application.Service;
using ClothingStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ClothCategoryService _service;
        public CategoryController(ClothCategoryService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothItem>>> GetCategoryProducts()
        {
            var ClothProducts = await _service.GetAllCategory();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(ClothProducts);
        }

        [HttpGet("{categoryId}")]
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

        [HttpGet("category/{categoryId}")]
        public async Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAsync(int categoryId)
        {
            return await _service.GetClothItemsByCategoryAsync(categoryId);
        }

        [HttpGet("clothcategory/{clothCategoryId}")]
        public async Task<IEnumerable<ClothItem>> GetClothItemsByClothCategoryAsync(int clothCategoryId)
        {
            return await _service.GetClothItemsByClothCategoryAsync(clothCategoryId);
        }

        [HttpGet("category/{categoryId}/clothcategory/{clothCategoryId}")]
        public async Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAndClothCategoryAsync(int categoryId, int clothCategoryId)
        {
            return await _service.GetClothItemsByCategoryAndClothCategoryAsync(categoryId, clothCategoryId);
        }

    }
}
