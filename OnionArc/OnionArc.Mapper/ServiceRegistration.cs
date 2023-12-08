using System;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using OnionArc.Application.Interfaces.Automapper;

namespace OnionArc.Mapper
{
    public static class ServiceRegistration
    {
        public static void AddCustomMapper(this IServiceCollection serviceCollection)
        {
            //IMapper bizimki mi automapper'ın mı? Projelerde dikkatli ol
            //aşağıdaki ikisi de kendi sınıfımızdan
            serviceCollection.AddSingleton<IMapper, Mapper>();
        }
    }
}

