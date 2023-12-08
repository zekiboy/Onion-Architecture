using System;
using Microsoft.EntityFrameworkCore;
using OnionArc.Application.Interfaces;
using OnionArc.Domain.Entities;
using OnionArc.Persistence.Configurations;

namespace OnionArc.Persistence.Context
{ 
	public class ApplicationDbContext : DbContext, IApplicationContext
    {
		public ApplicationDbContext()	{	}

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // ProductCategoryConfiguration aşağıdaki satır olmadan görmüyor. Bu yüzden migration oluştururken hata alırsın
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());



            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, categoryName = "Category 1" },
                new Category { Id = 2, categoryName = "Category 2" },
                new Category { Id = 3, categoryName = "Category 3" }
                );



            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, productName = "Product 1", Description = "Product 1 Description", Price = 1000, Stock = 10},
                new Product { Id = 2, productName = "Product 2", Description = "Product 2 Description", Price = 2000, Stock = 20},
                new Product { Id = 3, productName = "Product 3", Description = "Product 3 Description", Price = 3000, Stock = 30},
                new Product { Id = 4, productName = "Product 4", Description = "Product 4 Description", Price = 4000, Stock = 40}
                );


            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductId = 1, CategoryId = 1 },
                new ProductCategory { ProductId = 1, CategoryId = 2 },
                new ProductCategory { ProductId = 2, CategoryId = 1 },
                new ProductCategory { ProductId = 3, CategoryId = 2 },
                new ProductCategory { ProductId = 4, CategoryId = 2 }
                );
        }
    }

}

