using System;
using System.Globalization;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionArc.Application.Bases;
using OnionArc.Application.Beheviors;
using OnionArc.Application.Exceptions;
using OnionArc.Application.Features.Products.Queries.GetAllProducts;
using OnionArc.Application.Features.Products.Rules;

namespace OnionArc.Application
{
	public static class ServiceRegistration
	{
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            var assembly = Assembly.GetExecutingAssembly();

            serviceCollection.AddTransient<ExceptionMiddleware>();

            //serviceCollection.AddTransient<ProductRules>();
            //Yukarıdaki kullanım da çalışıf fakat her features için eklediğimizde çok kalabalık yapar, o yüzden bu kullanımı tercih ettik
            serviceCollection.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            serviceCollection.AddValidatorsFromAssembly(assembly);
            //FluentValidation.DependencyInjectionExtensions
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));


        }


        //AddRules
        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();

            foreach (var item in types)
                services.AddTransient(item);

            return services;
        }

    }
}

