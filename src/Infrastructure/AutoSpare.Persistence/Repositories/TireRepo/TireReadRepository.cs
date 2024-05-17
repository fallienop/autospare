using AutoSpare.Application.Repositories.TireRepo;
using AutoSpare.Domain.Entities;
using AutoSpare.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Repositories.TireRepo
{
    public class TireReadRepository : ReadRepository<Tire>, ITireReadRepository
    {
        public TireReadRepository(AutoSpareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
