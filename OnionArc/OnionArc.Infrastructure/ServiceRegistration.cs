using System;
using Microsoft.Extensions.DependencyInjection;
using OnionArc.Application.Interfaces;

namespace OnionArc.Infrastructure
{
	public static class ServiceRegistration
	{
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEmailService, EmailService>();
        }
    }
}

