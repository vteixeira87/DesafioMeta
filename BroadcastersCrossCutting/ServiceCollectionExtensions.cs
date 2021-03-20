using BroadcastersCrossCutting.HandlerResponseCross;
using BroadcastersCrossCutting.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersCrossCutting
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCrossCuttingDependencies(this IServiceCollection services)
        {
             
            services.AddScoped<IHandlerResponse, HandlerResponse>(); 

            return services;
        }
    }
}
