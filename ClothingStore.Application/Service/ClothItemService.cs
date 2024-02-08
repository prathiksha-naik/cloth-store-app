using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Service
{
    public class ClothItemService
    {
        private readonly IGenericRepository<ClothItem> _repository;
        private readonly IClothItemRepository _clothItemRepository;
        public ClothItemService(IGenericRepository<ClothItem> repository, IClothItemRepository clothItemRepository)
        {
            _repository = repository;
            _clothItemRepository = clothItemRepository;

        }
        public async Task<IEnumerable<ClothItem>> GetAllClothItems()
        {
            return await _clothItemRepository.GetAllClothProducts();
        }

        public async Task<ClothItem> GetClothItemById(int clothItemId)
        {
            return await _repository.GetByIdAsync(clothItemId);
        }
        public async Task<IEnumerable<ClothItem>> GetClothItemsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _clothItemRepository.GetClothItemsByPriceRangeAsync(minPrice, maxPrice);
        }
        public bool ClothItemExists(int clothItemId)
        {
            return  _clothItemRepository.ClothItemExists(clothItemId);
        }
    }
}
