using ClothingStore.Domain.Entities;

namespace ClothingStore.Application.Interface
{
    public interface IClothCategoryRepository
    {
        Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAsync(int categoryId);
        Task<IEnumerable<ClothItem>> GetClothItemsByClothCategoryAsync(int clothCategoryId);
        Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAndClothCategoryAsync(int categoryId, int clothCategoryId);
        Task<IEnumerable<ClothItem>> GetClothItemsByBrandNamesAsync(IEnumerable<string> brandName);
        bool ClothCategoryExists(int clothItemId);
    }
}
