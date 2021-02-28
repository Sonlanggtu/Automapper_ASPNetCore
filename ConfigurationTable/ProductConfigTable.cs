using FluentValidationASPNET.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationASPNET.ConfigurationTable
{
    public class ProductConfigTable : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);

            builder.Property(x => x.Name).IsRequired(true).HasColumnType("nvarchar(100)");

            builder.Property(x => x.Price).IsRequired(true);

            builder.HasOne(x => x.Customers).WithMany(x => x.Products).HasForeignKey(x => x.IdCustomer);
        }
    }
}
