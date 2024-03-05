using AutoSpare.Application.Repositories.CustomerRepo;
using AutoSpare.Application.Repositories.OrderRepo;
using AutoSpare.Domain.Entities;
using AutoSpare.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Repositories.CustomerRepo
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(AutoSpareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
