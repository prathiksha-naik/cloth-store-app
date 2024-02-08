using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure.Repository
{
    public class ClothItemGenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly DbSet<Entity> _dbSet;
        private readonly ClothStoreContext _context;
        public ClothItemGenericRepository(ClothStoreContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
        }
        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<Entity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }




    }
}
