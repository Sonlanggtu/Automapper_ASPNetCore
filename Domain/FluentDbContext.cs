using FluentValidationASPNET.ConfigurationTable;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationASPNET.Domain
{
    public class FluentDbContext : IdentityDbContext
    {
        public FluentDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { set; get; }
        public DbSet<Customer> Customers { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CustomerConfigTable());
            modelBuilder.ApplyConfiguration(new ProductConfigTable());
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                       .AddJsonFile("appsettings.Development.json", optional: true)
                                       .Build();
                string Fluentconnection = configuration.GetConnectionString("FluentValidationConnection");


                optionsBuilder.UseSqlServer(Fluentconnection);
            }
        }
    }
}
