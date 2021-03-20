using BroadcastersApplication.Interfaces;
using BroadcastersApplication.Service;
using BroadcastersCrossCutting;
using BroadcastersDomain;
using BroadcastersInfra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersApplication
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCrossCuttingDependencies()
                    .AddInfraDependencies()
                    .AddDomainDependencies()
                    .AddCrossCuttingDependencies();

            services.AddScoped<IBroadcastersAppService, BroadcastersAppService>();
            services.AddScoped<IAudienceAppService, AudienceAppService>();


            return services;
        }
    }
}
