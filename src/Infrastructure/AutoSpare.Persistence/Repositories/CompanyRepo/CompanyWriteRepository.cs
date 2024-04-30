using AutoSpare.Application.Repositories.CompanyRepo;
using AutoSpare.Domain.Entities;
using AutoSpare.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Repositories.CompanyRepo
{
    public class CompanyWriteRepository : WriteRepository<Company>, ICompanyWriteRepository
    {
        public CompanyWriteRepository(AutoSpareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
