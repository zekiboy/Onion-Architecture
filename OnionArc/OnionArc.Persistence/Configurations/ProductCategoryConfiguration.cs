using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArc.Domain.Entities;

namespace OnionArc.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.CategoryId });

            builder.HasOne(p => p.Product)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);
            //Bir product silindiğinde, productCategory içerisinde o producta ait olan tüm bağlantılar silinecek

            builder.HasOne(c => c.Category)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Cascade);
        } 
    }
}

