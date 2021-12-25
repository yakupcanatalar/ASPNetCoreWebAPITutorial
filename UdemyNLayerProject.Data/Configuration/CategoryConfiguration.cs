using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).UseIdentityColumn();
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);
            builder.ToTable("Categories");


        }
    }
}
