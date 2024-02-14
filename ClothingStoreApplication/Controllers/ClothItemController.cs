using ClothingStore.Application.Service;
using ClothingStore.Domain.Entities;
using ClothStoreApplication.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreApplication.Controllers
{
    [Route("ClothItems")]
    [ApiController]
    [Authorize]
    public class ClothItemController : ControllerBase
    {
        private readonly ClothItemService _clothItemService;
        public ClothItemController(ClothItemService clothItemService)
        {
            _clothItemService = clothItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothItem>>> GetAllClothItems()
        {
            var clothItems = await _clothItemService.GetAllClothItemsAsync();
            return Ok(clothItems);
        }

        [HttpGet("pricerange/{minPrice}/{maxPrice}")]
        public async Task<IEnumerable<ClothItem>> GetClothItemsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _clothItemService.GetClothItemsByPriceRangeAsync(minPrice, maxPrice);
        }

        [HttpPost]
        public async Task<ActionResult> AddClothItem(ClothItemDto clothItem)
        {
            await _clothItemService.AddClothItemAsync(clothItem);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateClothItem(ClothItemDto clothItem)
        {
            await _clothItemService.UpdateClothItemAsync(clothItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClothItem(int id)
        {
            await _clothItemService.DeleteClothItemAsync(id);
            return Ok();
        }
    }
}
