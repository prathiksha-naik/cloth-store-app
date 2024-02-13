using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Interface
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> GetByUserNameAsync(string username);
    }
}
