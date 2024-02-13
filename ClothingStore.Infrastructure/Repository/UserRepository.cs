﻿using ClothingStore.Application.Interface;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Infrastructure.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly ClothStoreContext _dbContext;
        public UserRepository(ClothStoreContext context) 
        { 
            _dbContext = context;
        }

        public async Task AddUser(User user)
        {
             await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByUserNameAsync(string username)
        {
            return await _dbContext.Users.Where(n=>n.Username ==username).FirstOrDefaultAsync();
        }
    }
}