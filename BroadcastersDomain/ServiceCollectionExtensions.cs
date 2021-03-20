using BroadcastersDomain.Queries.Request;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BroadcastersDomain
{
  public static  class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.ConfigureMediatR();

            return services;
        }

        private static void ConfigureMediatR(this IServiceCollection services)
        {
           services.AddMediatR(typeof(CreateBroadcastersCommand).GetTypeInfo().Assembly);
        }
    }
}
