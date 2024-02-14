using AutoMapper;
using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using ClothStoreApplication.DataTransferObjects;


namespace ClothingStore.Application.Service
{
    public class SizeVariantService
    {
        private readonly IMapper _mapper;
        private readonly ISizeForCloth _sizeRepository;

        public SizeVariantService( ISizeForCloth sizeRepository, IMapper mapper)
        {
           
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public async Task<List<SizeVariantDto>> GetAllSizeVariants()
        {
            var sizeVariants = await _sizeRepository.GetAllAsync();
            return _mapper.Map<List<SizeVariantDto>>(sizeVariants);
        }
        public async Task<IEnumerable<SizeVariant>> GetSizeVariantsForClothItem(int clothItemId)
        {
            return await _sizeRepository.GetSizeVariantsForClothItem(clothItemId);
        }

        public async Task<IEnumerable<ClothItem>> GetClothItemsByParticularSizeAsync(string size)
        {
            return await _sizeRepository.GetClothItemsByParticularSizeAsync(size);
        }

        public async Task<IEnumerable<ClothItem>> GetClothItemsBySizeRangeAsync(List<string> sizes)
        {
            return await _sizeRepository.GetClothItemsBySizeRangeAsync(sizes);
        }

        public bool ClothItemSizeExists(string size)
        {
            return _sizeRepository.ClothItemSizeExists(size);
        }
        public async Task AddSizeVariant(SizeVariantDto sizeVariantDto)
        {
            var sizeVariants = _mapper.Map<SizeVariant>(sizeVariantDto);
            await _sizeRepository.AddAsync(sizeVariants);
        }

        public async Task UpdateSizeVariant(SizeVariantDto sizeVariantDto)
        {
            var sizeVariants = _mapper.Map<SizeVariant>(sizeVariantDto);
            await _sizeRepository.UpdateAsync(sizeVariants);
        }

        public async Task DeleteBrand(int sizeVariantId)
        {
            await _sizeRepository.DeleteAsync(sizeVariantId);
        }

    }
}
