using AutoMapper;
using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using ClothStoreApplication.DataTransferObjects;

namespace ClothingStore.Application.Service
{
    public class ClothCategoryService
    {
        private readonly IGenericRepository<ClothCategory> _clothCategoryRepository;
        private readonly IClothCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ClothCategoryService(IGenericRepository<ClothCategory> Repository, IClothCategoryRepository clothCategoryRepository, IMapper mapper)
        {
            _clothCategoryRepository = Repository;
            _categoryRepository = clothCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ClothCategoryDto>> GetAllClothCategories()
        {
            var clothCategories = await _clothCategoryRepository.GetAllAsync();
            return _mapper.Map<List<ClothCategoryDto>>(clothCategories);
        }
        public async Task<IEnumerable<ClothItem>> GetClothItemsByClothCategoryAsync(int clothCategoryId)
        {
            return await _categoryRepository.GetClothItemsByClothCategoryAsync(clothCategoryId);
        }
        public async Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAndClothCategoryAsync(int categoryId, int clothCategoryId)
        {
            return await _categoryRepository.GetClothItemsByCategoryAndClothCategoryAsync(categoryId, clothCategoryId);
        }

        public async Task AddClothCategory(ClothCategoryDto clothCategoryDto)
        {
            var clothCategories = _mapper.Map<ClothCategory>(clothCategoryDto);
            await _clothCategoryRepository.AddAsync(clothCategories);
        }

        public async Task UpdateClothCategory(ClothCategoryDto clothCategoryDto)
        {
            var clothCategories = _mapper.Map<ClothCategory>(clothCategoryDto);
            await _clothCategoryRepository.UpdateAsync(clothCategories);
        }

        public async Task DeleteClothCategory(int clothCategoryId)
        {
            await _clothCategoryRepository.DeleteAsync(clothCategoryId);
        }

    }
}