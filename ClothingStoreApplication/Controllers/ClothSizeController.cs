using ClothingStore.Application.Service;
using ClothingStore.Domain.Entities;
using ClothingStore.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreApplication.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ClothSizeController : Controller
    {
        private readonly ClothSizeService _service;
        public ClothSizeController(ClothSizeService service)
        {
            _service = service;
        }

        [HttpGet("{clothItemId}/sizeVariants")]
        public async Task<IActionResult> GetSizeVariantsForClothItem(int clothItemId)
        {
            var sizeVariants = await _service.GetSizeVariantsForClothItem(clothItemId);
            return Ok(sizeVariants);
        }

        [HttpGet("bySize/{size}")]
        public async Task<IActionResult> GetClothItemsByParticularSize(string size)
        {
            var sizeExists = _service.ClothItemSizeExists(size);

            if (!sizeExists)
                return NotFound($"Size '{size}' not found.");

            var clothItems = await _service.GetClothItemsByParticularSizeAsync(size);
            return Ok(clothItems);
        }

        [HttpGet("bySizeRange")]
        public async Task<IActionResult> GetClothItemsBySizeRange([FromQuery] List<string> sizes)
        {
            var sizeNotExist = sizes.Where(size => !_service.ClothItemSizeExists(size));

            if (sizeNotExist.Any())
                return NotFound($"Sizes not found: {string.Join(", ", sizeNotExist)}");

            var clothItems = await _service.GetClothItemsBySizeRangeAsync(sizes);
            return Ok(clothItems);
        }

    }
}
