using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Interface
{
    public interface IClothCategoryRepository
    {
        Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAsync(int categoryId);
        Task<IEnumerable<ClothItem>> GetClothItemsByClothCategoryAsync(int clothCategoryId);

        Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAndClothCategoryAsync(int categoryId, int clothCategoryId);
        bool ClothCategoryExists(int clothItemId);

    }
}
