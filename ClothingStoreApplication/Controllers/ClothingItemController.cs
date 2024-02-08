using ClothingStore.Application.Interface;
using ClothingStore.Application.Service;
using ClothingStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClothingItemController : ControllerBase
    {
        private readonly ClothItemService _service;
        public ClothingItemController(ClothItemService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothItem>>> GetClothProducts()
        {
            var ClothProducts = await _service.GetAllClothItems();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(ClothProducts);
        }

        [HttpGet("{clothItemId}")]
        public async Task<ActionResult<ClothItem>> GetClothProduct(int clothItemId)
        {
            var clothItem = _service.ClothItemExists(clothItemId);
            if (clothItem == false)
                return NotFound();
            var product = await _service.GetClothItemById(clothItemId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(product);
        }

        [HttpGet("pricerange/{minPrice}/{maxPrice}")]
        public async Task<IEnumerable<ClothItem>> GetClothItemsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _service.GetClothItemsByPriceRangeAsync(minPrice, maxPrice);
        }


        //[HttpGet("SizeVariant/{clothItemId}")]
        //public IActionResult GetClothBySize(int clothItemId)
        //{
        //    var clothItem = _service.ClothItemExists(clothItemId);
        //    if (clothItem == false)
        //        return NotFound();

        //    var size = _service.GetSizeVariantsForClothItem(clothItemId);
        //    if (!ModelState.IsValid)
        //        return BadRequest();
        //    return Ok(size);
        //}



    }
}
