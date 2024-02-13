using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure.Repository
{
    public class ClothCategoryRepository : IClothCategoryRepository
    {
        private readonly ClothStoreContext _context;
        public ClothCategoryRepository(ClothStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAsync(int categoryId)
        {
            return await _context.ClothItems.Where(item => item.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<ClothItem>> GetClothItemsByClothCategoryAsync(int clothCategoryId)
        {
            return await _context.ClothItems.Where(item => item.ClothCategoryId == clothCategoryId).ToListAsync();
        }

        public async Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAndClothCategoryAsync(int categoryId, int clothCategoryId)
        {
            return await _context.ClothItems.Where(item => item.CategoryId == categoryId && item.ClothCategoryId == clothCategoryId).ToListAsync();
        }
        public async Task<IEnumerable<ClothItem>> GetClothItemsByBrandNamesAsync(IEnumerable<string> brandNames)
        {
            var clothItems = await _context.ClothItems
                .Join(_context.Brands,
                      clothItem => clothItem.BrandId,
                      brand => brand.BrandId,
                      (clothItem, brand) => new { ClothItem = clothItem, Brand = brand })
                .Where(item => brandNames.Contains(item.Brand.BrandName))
                .Select(item => item.ClothItem)
                .ToListAsync();

            return clothItems;
        }
        public async Task<IEnumerable<ClothItem>> GetClothItemsBySizeRangeAsync(List<string> sizes)
        {
            return await _context.SizeVariants
                .Where(item => sizes.Contains(item.Size))
                .Select(item => item.ClothItem)
                .ToListAsync();


        }
        public bool ClothCategoryExists(int catId)
        {
            return _context.Categories.Any(c => c.CategoryId == catId);
        }


    }
}
