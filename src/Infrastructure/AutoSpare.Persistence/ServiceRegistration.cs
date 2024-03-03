using AutoSpare.Application.Abstractions;
using AutoSpare.Persistence.Concretes;
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
        public static void AddPersistenceServices( this IServiceCollection services) 
        {
            services.AddSingleton<IMakeService, MakeService>();
        }
    }
}
