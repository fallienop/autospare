﻿using AutoSpare.Application.Repositories;
using AutoSpare.Domain.Entities;
using AutoSpare.Domain.Entities.Common;
using AutoSpare.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AutoSpare.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AutoSpareDbContext _dbContext;

        public ReadRepository(AutoSpareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public  IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
            {
                query=query.AsNoTracking();
            }
          
                return  query;

        }
               
            

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query.Where(method);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query= Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(method);

        }
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(entity => entity.Id == Guid.Parse(id));
        }

        //public string GetTableName<T>() where T : class
        //{
        //    var entityType = _dbContext.Model.FindEntityType(typeof(T));
        //    var schema = entityType.GetSchema();
        //    var tableName = entityType.GetTableName();
        //    return tableName;
        //}

        //public IQueryable<T> GetWithQueryAsync(Expression<Func<T, bool>> filterExpression,bool tracking=true)
        //{
        //    //string tableName = GetTableName<T>();
        //    var query= Table.Where(filterExpression);
        //    //var query = Table.FromSqlInterpolated($"select * from {tableName} where {property} like {pattern}").AsQueryable();
        //    //var query1 = Table.FromSqlInterpolated($"select * from {tableName} where {property} like {pattern}");
        //    //Console.WriteLine($"select * from {tableName} where {property} like '{pattern}'");
        //    if (!tracking)
        //    {
        //        query = query.AsNoTracking();
        //    }

        //    return query;

        //}
    }
}
