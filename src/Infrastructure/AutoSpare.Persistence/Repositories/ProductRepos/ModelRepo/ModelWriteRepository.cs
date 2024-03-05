using AutoSpare.Application.Repositories.ProductRepos.ModelRepo;
using AutoSpare.Application.Repositories.ProductRepos.PartRepo;
using AutoSpare.Domain.Entities.Product;
using AutoSpare.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Repositories.ProductRepos.ModelRepo
{
    public class ModelWriteRepository : WriteRepository<Model>, IModelWriteRepository
    {
        public ModelWriteRepository(AutoSpareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
