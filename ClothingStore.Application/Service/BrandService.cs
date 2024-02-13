using AutoMapper;
using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using ClothStoreApplication.DataTransferObjects;

namespace ClothingStore.Application.Service
{
    public class BrandService
    {
        private readonly IGenericRepository<Brand> _brandRepository;
        private readonly IClothCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public BrandService(IGenericRepository<Brand> brandRepository, IClothCategoryRepository categoryRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<BrandDto>> GetAllBrands()
        {
            var brands = await _brandRepository.GetAllAsync();
            return _mapper.Map<List<BrandDto>>(brands);
        }
        public async Task<IEnumerable<ClothItem>> GetClothItemsByBrandNamesAsync(IEnumerable<string> brandNames)
        {
            return await _categoryRepository.GetClothItemsByBrandNamesAsync(brandNames);
        }

        public async Task AddBrand(BrandDto brandDto)
        {
            var brand = _mapper.Map<Brand>(brandDto);
            await _brandRepository.AddAsync(brand);
        }

        public async Task UpdateBrand(BrandDto brandDto)
        {
            var brand = _mapper.Map<Brand>(brandDto);
            await _brandRepository.UpdateAsync(brand);
        }

        public async Task DeleteBrand(int brandId)
        {
            await _brandRepository.DeleteAsync(brandId);
        }
    }
}