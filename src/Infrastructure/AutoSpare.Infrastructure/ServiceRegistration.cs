using AutoSpare.Application.Abstractions.Services;
using AutoSpare.Application.Abstractions.TokenAbstraction;
using AutoSpare.Infrastructure.Services.Storage;
using AutoSpare.Infrastructure.Services.TokenService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService,FileService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
