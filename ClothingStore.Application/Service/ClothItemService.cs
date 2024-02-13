using AutoMapper;
using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using ClothStoreApplication.DataTransferObjects;

namespace ClothingStore.Application.Service
{
    public class ClothItemService
    {
        private readonly IGenericRepository<ClothItem> _repository;
        private readonly IClothItemRepository _clothItemRepository;
        private readonly IMapper _mapper;


        public ClothItemService(IGenericRepository<ClothItem> Repository, IClothItemRepository clothItemRepository, IMapper mapper)
        {
            _repository = Repository;
            _mapper = mapper;
            _clothItemRepository = clothItemRepository;
        }

        public async Task<IEnumerable<ClothItemDto>> GetAllClothItemsAsync()
        {
            var clothItems = await _clothItemRepository.GetAllClothProducts();
            return _mapper.Map<IEnumerable<ClothItemDto>>(clothItems);
        }
        //public async Task<IEnumerable<ClothItem>> GetAllClothItems()
        //{
        //    return await _clothItemRepository.GetAllClothProducts();
        //}
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
            await _repository.AddAsync(clothItem);
        }

        public async Task UpdateClothItemAsync(ClothItemDto clothItemDto)
        {
            var clothItem = _mapper.Map<ClothItem>(clothItemDto);
            await _repository.UpdateAsync(clothItem);
        }

        public async Task DeleteClothItemAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
