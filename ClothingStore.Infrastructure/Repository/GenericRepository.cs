using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly ClothStoreContext _dbContext;
        public GenericRepository(ClothStoreContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {

            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        //public async Task<T> GetByUserNameAsync(string username)
        //{
        //    // Assuming that the entity T has a property called "UserName"
        //    if (typeof(T).GetProperty("Username") == null)
        //    {
        //        throw new InvalidOperationException("The entity does not have a UserName property.");
        //    }

        //    return await _dbSet.SingleOrDefaultAsync(e => EF.Property<string>(e, "Username") == username);
        //}
    }




}

