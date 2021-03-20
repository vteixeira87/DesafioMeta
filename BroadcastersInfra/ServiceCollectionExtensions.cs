using BroadcastersDomain.Interfaces.Repositories;
using BroadcastersInfra.Context;
using BroadcastersInfra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersInfra
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraDependencies(this IServiceCollection services)
        {
            services.AddScoped<BroadcastersContext>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBroadcastersRepository, BroadcastersRepository>();
            services.AddScoped<IAudienceRepository, AudienceRepository>();
           

            return services;
        }
    }
}
