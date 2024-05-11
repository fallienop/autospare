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
    public class PlateWriteRepository : WriteRepository<Plate>, IPlateWriteRepository
    {
        public PlateWriteRepository(AutoSpareDbContext dbContext) : base(dbContext)
        {

        }
    }
}
