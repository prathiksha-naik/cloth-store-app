using AutoMapper;
using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using ClothStoreApplication.DataTransferObjects;

namespace ClothingStore.Application.Service
{
    public class ClothItemService
    {
        private readonly IClothItemRepository _clothItemRepository;
        private readonly IMapper _mapper;


        public ClothItemService( IClothItemRepository clothItemRepository, IMapper mapper)
        {
            _mapper = mapper;
            _clothItemRepository = clothItemRepository;
        }

        public async Task<IEnumerable<ClothItem>> GetAllClothItemsAsync()
        {
            return await _clothItemRepository.GetAllClothProducts();
           
        }
        
        public async Task<IEnumerable<ClothItem>> GetClothItemsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _clothItemRepository.GetClothItemsByPriceRangeAsync(minPrice, maxPrice);
        }
        public bool ClothItemExists(int clothItemId)
        {
            return _clothItemRepository.ClothItemExists(clothItemId);
        }

        public async Task AddClothItemAsync(ClothItemDto clothItemDto)
        {
            var clothItem = _mapper.Map<ClothItem>(clothItemDto);
            await _clothItemRepository.AddAsync(clothItem);
        }

        public async Task UpdateClothItemAsync(ClothItemDto clothItemDto)
        {
            var clothItem = _mapper.Map<ClothItem>(clothItemDto);
            await _clothItemRepository.UpdateAsync(clothItem);
        }

        public async Task DeleteClothItemAsync(int id)
        {
            await _clothItemRepository.DeleteAsync(id);
        }
    }
}
