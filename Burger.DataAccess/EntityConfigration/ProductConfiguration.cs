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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("money");

            builder.Property(p => p.Description)
                .HasColumnType("varchar(100)");


            builder
                .HasOne(Product=>Product.Category)
                .WithMany(Category=>Category.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
