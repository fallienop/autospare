using AutoSpare.Application.Repositories;
using AutoSpare.Application.Repositories.CategoryRepo;
using AutoSpare.Domain.Entities;
using AutoSpare.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Repositories.CategoryRepo
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(AutoSpareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
