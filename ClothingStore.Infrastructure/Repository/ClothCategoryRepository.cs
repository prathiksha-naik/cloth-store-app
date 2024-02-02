using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool ClothCategoryExists(int catId)
        {
            return _context.Categories.Any(c => c.CategoryId == catId);
        }

    }
}
