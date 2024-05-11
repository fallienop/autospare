
using AutoSpare.Application.Abstractions.Services;
using AutoSpare.Application.Repositories.BrandRepo;
using AutoSpare.Application.Repositories.CategoryRepo;
using AutoSpare.Application.Repositories.CompanyRepo;

using AutoSpare.Application.Repositories.OrderRepo;
using AutoSpare.Application.Repositories.PlateRepo;
using AutoSpare.Application.Repositories.ProductRepos.MakeRepo;
using AutoSpare.Application.Repositories.ProductRepos.ModelRepo;
using AutoSpare.Application.Repositories.ProductRepos.PartRepo;
using AutoSpare.Domain.Entities.Identity;
using AutoSpare.Persistence.Contexts;
using AutoSpare.Persistence.Repositories.BrandRepo;
using AutoSpare.Persistence.Repositories.CategoryRepo;
using AutoSpare.Persistence.Repositories.CompanyRepo;
using AutoSpare.Persistence.Repositories.OrderRepo;
using AutoSpare.Persistence.Repositories.PlateRepo;
using AutoSpare.Persistence.Repositories.ProductRepos.MakeRepo;
using AutoSpare.Persistence.Repositories.ProductRepos.ModelRepo;
using AutoSpare.Persistence.Repositories.ProductRepos.PartRepo;
using AutoSpare.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = true;
            }).AddRoles<AppRole>().AddEntityFrameworkStores<AutoSpareDbContext>();


            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IMakeReadRepository, MakeReadRepository>();
            services.AddScoped<IMakeWriteRepository, MakeWriteRepository>();

            services.AddScoped<IModelReadRepository, ModelReadRepository>();
            services.AddScoped<IModelWriteRepository, ModelWriteRepository>();

            services.AddScoped<IPartReadRepository, PartReadRepository>();
            services.AddScoped<IPartWriteRepository, PartWriteRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

            services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();

            services.AddScoped<IPlateReadRepository, PlateReadRepository>();
            services.AddScoped<IPlateWriteRepository, PlateWriteRepository>();

            services.AddScoped<IUserService, UserService>();

        }
    }
}
