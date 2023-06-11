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
    internal class FinalOrderConfiguration : IEntityTypeConfiguration<FinalOrder>
    {
        public void Configure(EntityTypeBuilder<FinalOrder> builder)
        {
            builder.ToTable("FinalOrder"); 

            builder.HasKey(o => o.Id); 


            builder.HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(f => f.Order)
                .WithOne()
                .HasForeignKey<FinalOrder>(o => o.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
