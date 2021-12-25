using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Data.Configuration;
using UdemyNLayerProject.Data.Seeds;

namespace UdemyNLayerProject.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options):base(options)
        {

        }
        public DbSet <Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tabloların detayları burada tanımlanır.
            //modelBuilder.Entity<Product>().Property(_ => _.Id).IsRequired();  böyle de yapılır ancak karışır.
            //Config altında yapmak daha düzenli.
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            //For seed için
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1,2}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));

        }

    }
}
