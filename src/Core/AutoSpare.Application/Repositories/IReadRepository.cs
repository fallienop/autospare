using AutoSpare.Domain.Entities;
using AutoSpare.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T,bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T,bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
        //IQueryable<T> GetWithQueryAsync(string property, string pattern, bool tracking = true);
        //IQueryable<T> GetWithQueryAsync(Expression<Func<T, bool>> filterExpression, bool tracking = true);
    }
}
