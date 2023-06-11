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
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable(nameof(Ingredient));
            builder.HasKey(Ingredient => Ingredient.Id);
            builder.Property(Ingredient => Ingredient.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(Ingredient => Ingredient.Price)
                .HasColumnType("money");

            builder.HasData(
                new Ingredient() { Id = 1, Name = "Köfte",Price=75 },
                new Ingredient() { Id = 2, Name = "Cheddar",Price=25 },
                new Ingredient() { Id = 3, Name = "Marul",Price=0 },
                new Ingredient() { Id = 4, Name = "Füme Et",Price=50 },
                new Ingredient() { Id = 5, Name = "Kaburga",Price=50 }
                );
        }
    }
}
