using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).UseIdentityColumn();
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(200);
            builder.Property(_ => _.Stock).IsRequired();
            builder.Property(_ => _.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(_ => _.InnerBarcode).HasMaxLength(50);
            builder.ToTable("Products");
        }
    }
}
