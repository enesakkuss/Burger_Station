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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasData(
                new Category() { Id = 1, Name = "Ana Ürün" },
                new Category() { Id = 2, Name = "Yan Ürün" },
                new Category() { Id = 3, Name = "İçecek" },
                new Category() { Id = 4, Name = "Tatlı" }
                );
        }

        
    }
}
