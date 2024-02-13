using AutoMapper;
using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using ClothStoreApplication.DataTransferObjects;


namespace ClothingStore.Application.Service
{
    public class CategoryService
    {
        private readonly IGenericRepository<Category> _repository;
        private readonly IClothCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> categoryRepository, IClothCategoryRepository clothCategoryRepository, IMapper mapper)
        {
            _repository = categoryRepository;
            _categoryRepository = clothCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
        public async Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAsync(int categoryId)
        {
            return await _categoryRepository.GetClothItemsByCategoryAsync(categoryId);
        }
        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var categories = _mapper.Map<Category>(categoryDto);
            await _repository.AddAsync(categories);
        }

        public async Task UpdateCategoryAsync(CategoryDto categoryDto)
        {
            var categories = _mapper.Map<Category>(categoryDto);
            await _repository.UpdateAsync(categories);
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _repository.DeleteAsync(categoryId);
        }
        public bool CategoryItemExist(int categoryId)
        {
            return _categoryRepository.ClothCategoryExists(categoryId);
        }
    }
}