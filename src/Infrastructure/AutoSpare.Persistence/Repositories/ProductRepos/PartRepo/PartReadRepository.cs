using AutoSpare.Application.Repositories.ProductRepos.PartRepo;
using AutoSpare.Domain.Entities.Product;
using AutoSpare.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Repositories.ProductRepos.PartRepo
{
    public class PartReadRepository : ReadRepository<Part>, IPartReadRepository
    {
        public PartReadRepository(AutoSpareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
