using AutoSpare.Application.Repositories;
using AutoSpare.Application.Repositories.PlateRepo;
using AutoSpare.Domain.Entities;
using AutoSpare.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Repositories.PlateRepo
{
    public class PlateReadRepository : ReadRepository<Plate>, IPlateReadRepository
    {
        public PlateReadRepository(AutoSpareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
