using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ClothStoreContext _dbContext;
        public UserRepository(ClothStoreContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<User> GetByUserNameAsync(string username)
        {
            return await _dbContext.Users.Where(n => n.Username == username).FirstOrDefaultAsync();
        }
    }
}
