using AutoMapper;
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
    public class BrandsController : ControllerBase
    {
        private readonly BrandService _brandService;
        private readonly IMapper _mapper;

        public BrandsController(BrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var brands = await _brandService.GetAllBrands();
            return Ok(brands);
        }
        [HttpGet("GetClothItemsByBrandNames")]
        public async Task<IEnumerable<ClothItem>> GetClothItemsByBrandNamesAsync([FromQuery] IEnumerable<string> brandNames)
        {

            return await _brandService.GetClothItemsByBrandNamesAsync(brandNames);
        }
        [HttpPost]
        public async Task<ActionResult> AddBrand([FromBody] BrandDto brandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _brandService.AddBrand(brandDto);
            return CreatedAtAction(nameof(AddBrand), brandDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBrand(int id, [FromBody] BrandDto brandDto)
        {
            if (id != brandDto.BrandId)
            {
                return BadRequest();
            }

            await _brandService.UpdateBrand(brandDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBrandAsync(int id)
        {
            await _brandService.DeleteBrand(id);
            return NoContent();
        }
    }
}

