namespace ClothingStore.Application.Interface
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync(int id);



    }
}
