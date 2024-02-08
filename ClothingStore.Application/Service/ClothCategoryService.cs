using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Service
{
    public class ClothCategoryService
    {
        private readonly IGenericRepository<Category> _repository;
        private readonly IClothCategoryRepository _categoryRepository;
        public ClothCategoryService(IGenericRepository<Category> repository,IClothCategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category> GetCategoryById(int clothItemId)
        {
            return await _repository.GetByIdAsync(clothItemId);
        }
        public async Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAsync(int categoryId)
        {
            return await _categoryRepository.GetClothItemsByCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<ClothItem>> GetClothItemsByClothCategoryAsync(int clothCategoryId)
        {
            return await _categoryRepository.GetClothItemsByClothCategoryAsync(clothCategoryId);
        }

        public async Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAndClothCategoryAsync(int categoryId, int clothCategoryId)
        {
            return await _categoryRepository.GetClothItemsByCategoryAndClothCategoryAsync(categoryId, clothCategoryId);
        }
        public async Task<IEnumerable<ClothItem>> GetClothItemsByBrandNamesAsync(IEnumerable<string> brandNames)
        {
            return await _categoryRepository.GetClothItemsByBrandNamesAsync(brandNames);
        }

        public bool CategoryItemExist(int categoryId)
        {
            return _categoryRepository.ClothCategoryExists(categoryId);
        }

    }
}
