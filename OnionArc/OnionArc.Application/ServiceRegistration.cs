using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionArc.Application.Features.Products.Queries.GetAllProducts;

namespace OnionArc.Application
{
	public static class ServiceRegistration
	{
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            var assembly = Assembly.GetExecutingAssembly();
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        }
    }
}

