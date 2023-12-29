 using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArc.Application.Interfaces;
using OnionArc.Domain.Entities;
using OnionArc.Persistence.Context;
using OnionArc.Persistence.Repositories;
using OnionArc.Persistence.UnitOfWorks;

namespace OnionArc.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration  configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            //serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            //serviceCollection.AddTransient<ICategoryRepository, CategoryRepository>();
            
            serviceCollection.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            serviceCollection.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddIdentityCore<User>(opt=>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;

            })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

        }
    }
}

