using AutoSpare.Application.Repositories.ProductRepos.ModelRepo;
using AutoSpare.Domain.Entities.Product;
using AutoSpare.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Repositories.ProductRepos.ModelRepo
{
    public class ModelReadRepository : ReadRepository<Model>, IModelReadRepository
    {
        public ModelReadRepository(AutoSpareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
