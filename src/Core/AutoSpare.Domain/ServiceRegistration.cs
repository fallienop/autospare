//using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application
{
    public static class ServiceRegistration
    {
        public static void AddDomainRegistration(this IServiceCollection services) 
        {            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new AutoMapperProfile());
            //});

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
            //services.AddMediatR(typeof(ServiceRegistration));
            //services.AddAutoMapper(typeof(AutoMapperProfile));
        }

    }
}
