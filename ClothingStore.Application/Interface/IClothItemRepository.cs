using ClothingStore.Domain.Entities;

namespace ClothingStore.Application.Interface
{
    public interface IClothItemRepository:IGenericRepository<ClothItem>
    {
       
        Task<IEnumerable<ClothItem>> GetClothItemsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<ClothItem>> GetAllClothProducts();
        bool ClothItemExists(int clothItemId);

    }
}
