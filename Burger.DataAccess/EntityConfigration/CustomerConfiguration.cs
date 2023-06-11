using BurgerStation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.DataAccess.EntityConfigration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(x => x.LastName)
            .IsRequired()
            .HasColumnType("nvarchar(50)");

            builder.Property(x => x.Mail)
            .IsRequired()
            .HasColumnType("nvarchar(50)");

            builder.Property(x => x.PhoneNumber)
            .IsRequired()
            .HasColumnType("nvarchar(50)");

            builder.Property(x => x.Address)
            .IsRequired()
            .HasColumnType("nvarchar(100)");


            builder.Navigation(x => x.District).AutoInclude();
            builder.Navigation(x=>x.Neighborhood).AutoInclude();
        }
    }
}
