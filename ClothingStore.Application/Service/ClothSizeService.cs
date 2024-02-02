using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Service
{
    public class ClothSizeService
    {
        private readonly ISizeForCloth _sizeRepository;
        public ClothSizeService(ISizeForCloth sizeRepository)
        {

            _sizeRepository = sizeRepository;

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

    }
}
