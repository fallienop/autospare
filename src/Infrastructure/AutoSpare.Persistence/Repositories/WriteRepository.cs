﻿using AutoSpare.Application.Repositories;
using AutoSpare.Domain.Entities.Common;
using AutoSpare.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly AutoSpareDbContext _dbContext;

        public WriteRepository(AutoSpareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
         EntityEntry<T> entityEntry= await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T data = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Remove(data);
          
        }

        public bool Remove(T entity)
        {
          EntityEntry entityEntry=  Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }
      
        public bool Update(T entity)
        {
          EntityEntry entityEntry=  Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
           => await _dbContext.SaveChangesAsync();

    }
}
