
using AutoSpare.Application.Repositories.CustomerRepo;
using AutoSpare.Application.Repositories.OrderRepo;
using AutoSpare.Application.Repositories.ProductRepos.MakeRepo;
using AutoSpare.Application.Repositories.ProductRepos.ModelRepo;
using AutoSpare.Application.Repositories.ProductRepos.PartRepo;
using AutoSpare.Persistence.Contexts;
using AutoSpare.Persistence.Repositories.CustomerRepo;
using AutoSpare.Persistence.Repositories.OrderRepo;
using AutoSpare.Persistence.Repositories.ProductRepos.MakeRepo;
using AutoSpare.Persistence.Repositories.ProductRepos.ModelRepo;
using AutoSpare.Persistence.Repositories.ProductRepos.PartRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AutoSpareDbContext>(opt =>

            {
                opt.UseSqlServer(DbConnectionStringConfiguration.ConnectionString);
            });
                
            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();  
            services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            
            services.AddScoped<IMakeReadRepository, MakeReadRepository>();
            services.AddScoped<IMakeWriteRepository, MakeWriteRepository>();

            services.AddScoped<IModelReadRepository, ModelReadRepository>();
            services.AddScoped<IModelWriteRepository, ModelWriteRepository>();

            services.AddScoped<IPartReadRepository, PartReadRepository>();
            services.AddScoped<IPartWriteRepository, PartWriteRepository>();

        }
    }
}
