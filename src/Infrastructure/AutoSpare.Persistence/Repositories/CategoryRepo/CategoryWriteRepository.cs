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
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(AutoSpareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
