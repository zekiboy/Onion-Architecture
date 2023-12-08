using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArc.Domain.Entities;

namespace OnionArc.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {


        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.productName).HasMaxLength(150);
        }
    }
}

