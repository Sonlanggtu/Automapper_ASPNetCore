using FluentValidationASPNET.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationASPNET.ConfigurationTable
{
    public class CustomerConfigTable : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.Property(x => x.FullName).HasColumnType("nvarchar(50)").IsRequired(true);

            builder.Property(x => x.Gender).IsRequired(true);


        }
    }
}
