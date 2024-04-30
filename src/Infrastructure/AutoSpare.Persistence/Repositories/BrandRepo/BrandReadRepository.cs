using AutoSpare.Application.Repositories.BrandRepo;
using AutoSpare.Domain.Entities.Product;
using AutoSpare.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Repositories.BrandRepo
{
    public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
    {
        public BrandReadRepository(AutoSpareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
