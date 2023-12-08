using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace OnionArc.Persistence.Context
{
	public class ApplicationDbContextFactory : DesignTimeDbContextFactory<ApplicationDbContext>
    {
        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }
    }
}

