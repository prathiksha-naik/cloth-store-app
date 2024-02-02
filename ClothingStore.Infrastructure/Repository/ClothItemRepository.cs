using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure.Repository
{
    public class ClothItemRepository : IClothItemRepository
    {
        private readonly ClothStoreContext _context;
        public ClothItemRepository(ClothStoreContext context)
        {
            _context = context;

        }
        public bool ClothItemExists(int clothItemId)
        {
            return _context.ClothItems.Any(c => c.ClothItemId == clothItemId);
        }

        public async Task<IEnumerable<ClothItem>> GetClothItemsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _context.ClothItems.Where(item => item.Price >= minPrice && item.Price <= maxPrice).ToListAsync(); ;
        }



        //public ICollection<ClothItem> GetClothItems()
        //{
        //    return _context.ClothItems.ToList();
        //}
        //public ClothItem GetClothItem(int clothItemId)
        //{
        //    return _context.ClothItems.Where(c => c.ClothItemId == clothItemId).FirstOrDefault();
        //}

        //public ICollection<SizeVariant> GetSizeVariantsForClothItem(int clothItemId)
        //{
        //    return  _context.ClothItems
        //        .Where(c => c.ClothItemId == clothItemId)
        //        .SelectMany(c => c.SizeVariants)
        //        .ToList();
        //}

    }
}
