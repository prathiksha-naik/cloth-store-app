using ClothingStore.Domain.Entities;

namespace ClothingStore.Application.Interface
{
    public interface ISizeForCloth
    {
        Task<IEnumerable<SizeVariant>> GetSizeVariantsForClothItem(int clothItemId);
        Task<IEnumerable<ClothItem>> GetClothItemsByParticularSizeAsync(string size);
        Task<IEnumerable<ClothItem>> GetClothItemsBySizeRangeAsync(List<string> sizes);
        bool ClothItemSizeExists(string size);
    }
}
