using AutoMapper;
using ClothingStore.Application.Service;
using ClothStoreApplication.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreApplication.Controllers
{
    [Route("SizeVariants")]
    [ApiController]
    [Authorize]
    public class SizeVariantController : ControllerBase
    {
        private readonly SizeVariantService _sizeVariantService;
        private readonly IMapper _mapper;

        public SizeVariantController(SizeVariantService sizeVariantService, IMapper mapper)
        {
            _sizeVariantService = sizeVariantService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeVariantDto>>> GetAllSizeVariants()
        {
            var sizeVariants = await _sizeVariantService.GetAllSizeVariants();
            return Ok(sizeVariants);
        }
        [HttpGet("{clothItemId}/sizeVariants")]
        public async Task<IActionResult> GetSizeVariantsForClothItem(int clothItemId)
        {
            var sizeVariants = await _sizeVariantService.GetSizeVariantsForClothItem(clothItemId);
            return Ok(sizeVariants);
        }

        [HttpGet("bySize/{size}")]
        public async Task<IActionResult> GetClothItemsByParticularSize(string size)
        {
            var sizeExists = _sizeVariantService.ClothItemSizeExists(size);

            if (!sizeExists)
                return NotFound($"Size '{size}' not found.");

            var clothItems = await _sizeVariantService.GetClothItemsByParticularSizeAsync(size);
            return Ok(clothItems);
        }

        [HttpGet("bySizeRange")]
        public async Task<IActionResult> GetClothItemsBySizeRange([FromQuery] List<string> sizes)
        {
            var sizeNotExist = sizes.Where(size => !_sizeVariantService.ClothItemSizeExists(size));

            if (sizeNotExist.Any())
                return NotFound($"Sizes not found: {string.Join(", ", sizeNotExist)}");

            var clothItems = await _sizeVariantService.GetClothItemsBySizeRangeAsync(sizes);
            return Ok(clothItems);
        }

        [HttpPost]
        public async Task<ActionResult> AddSizeVariant([FromBody] SizeVariantDto sizeVariantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sizeVariantService.AddSizeVariant(sizeVariantDto);
            return CreatedAtAction(nameof(AddSizeVariant), sizeVariantDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSizeVariant(int id, [FromBody] SizeVariantDto sizeVariantDto)
        {
            if (id != sizeVariantDto.SizeId)
            {
                return BadRequest();
            }

            await _sizeVariantService.UpdateSizeVariant(sizeVariantDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSizeVariantAsync(int id)
        {
            await _sizeVariantService.DeleteBrand(id);
            return NoContent();
        }
    }
}

