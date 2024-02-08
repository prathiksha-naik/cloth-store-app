using ClothingStore.Domain.Entities;

namespace ClothingStore.Application.Interface
{
    public interface IClothItemRepository
    {
        //ICollection<ClothItem> GetClothItems();
        //ClothItem GetClothItem(int clothItemId);
        // ICollection<SizeVariant> GetSizeVariantsForClothItem(int clothItemId);
        // Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAsync(int categoryId);
        //Task<IEnumerable<ClothItem>> GetClothItemsByClothCategoryAsync(int clothCategoryId);
        //Task<IEnumerable<ClothItem>> GetClothItemsByCategoryAndClothCategoryAsync(int categoryId, int clothCategoryId);
        Task<IEnumerable<ClothItem>> GetClothItemsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<ClothItem>> GetAllClothProducts();
        bool ClothItemExists(int clothItemId);

    }
}
