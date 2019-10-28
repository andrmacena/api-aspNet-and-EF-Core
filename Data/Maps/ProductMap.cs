using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Models;

namespace ProductCatalog.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(prod => prod.Id);
            builder.Property(prod => prod.CreateDate).IsRequired();
            builder.Property(prod => prod.Description).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.Property(prod => prod.Image).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.Property(prod => prod.LastUpdateDate).IsRequired();
            builder.Property(prod => prod.Price).IsRequired().HasColumnType("money");
            builder.Property(prod => prod.Quantity).IsRequired();
            builder.Property(prod => prod.Title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.HasOne(prod => prod.Category).WithMany(products => products.Products);
        }
    }
}