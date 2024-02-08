using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure.Repository
{
    public class ClothSizeRepository : ISizeForCloth
    {
        private readonly ClothStoreContext _context;
        public ClothSizeRepository(ClothStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClothItem>> GetClothItemsByParticularSizeAsync(string size)
        {
            return await _context.SizeVariants
                    .Where(item => item.Size == size).Select(item => item.ClothItem)
                    .ToListAsync();
        }

        public async Task<IEnumerable<ClothItem>> GetClothItemsBySizeRangeAsync(List<string> sizes)
        {
                return await _context.SizeVariants
                    .Where(item => sizes.Contains(item.Size))
                    .Select(item => item.ClothItem)
                    .ToListAsync();
            
            
        }


        public async Task<IEnumerable<SizeVariant>> GetSizeVariantsForClothItem(int clothItemId)
        {
            return await _context.SizeVariants
                .Where(sv => sv.ClothItemId == clothItemId)
                .ToListAsync();
        }

        public bool ClothItemSizeExists(string size)
        {
            return _context.SizeVariants.Any(sv => sv.Size == size);
        }

    }
}
