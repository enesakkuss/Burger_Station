using BurgerStation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.DataAccess.EntityConfigration
{
    internal class NeighborhoodConfiguration : IEntityTypeConfiguration<Neighborhood>
    {
        public void Configure(EntityTypeBuilder<Neighborhood> builder)
        {
            builder.ToTable(nameof(Neighborhood));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.HasData(
                new Neighborhood() { Id = 1, Name = "	100. YIL MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 2, Name = "15 TEMMUZ MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 3, Name = "BAĞLAR MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 4, Name = "BARBAROS MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 5, Name = "ÇINAR MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 6, Name = "DEMİRKAPI MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 7, Name = "FATİH MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 8, Name = "FEVZİ ÇAKMAK MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 9, Name = "GÖZTEPE MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 10,Name = "GÜNEŞLİ MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 11,Name = "HÜRRİYET MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 12,Name = "İNÖNÜ MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 13,Name = "KAZIM KARABEKİR MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 14,Name = "KEMALPAŞA MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 15,Name = "KİRAZLI MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 16,Name = "MAHMUTBEY MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 17,Name = "MERKEZ MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 18,Name = "SANCAKTEPE MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 19,Name = "YAVUZ SELİM MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 20,Name = "YENİGÜN MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 21,Name = "YENİMAHALLE MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 22,Name = "YILDIZTEPE MAHALLESİ", DistrictId = 1 },
                new Neighborhood() { Id = 23,Name = "BAHÇELİEVLER MAHALLESİ", DistrictId = 2 },
                new Neighborhood() { Id = 24,Name = "CUMHURİYET MAHALLESİ", DistrictId = 2 },
                new Neighborhood() { Id = 25,Name = "ÇOBANÇEŞME MAHALLESİ", DistrictId = 2 },
                new Neighborhood() { Id = 26,Name = "FEVZİ ÇAKMAK MAHALLESİ", DistrictId = 2 },
                new Neighborhood() { Id = 27,Name = "HÜRRİYET MAHALLESİ", DistrictId = 2 },
                new Neighborhood() { Id = 28,Name = "KOCASİNAN MERKEZ MAHALLESİ", DistrictId = 2 },
                new Neighborhood() { Id = 29,Name = "SİYAVUŞPAŞA MAHALLESİ", DistrictId = 2 },
                new Neighborhood() { Id = 30,Name = "SOĞANLI MAHALLESİ", DistrictId = 2 },
                new Neighborhood() { Id = 31,Name = "ŞİRİNEVLER MAHALLESİ", DistrictId = 2 },
                new Neighborhood() { Id = 32,Name = "YENİBOSNA MERKEZ MAHALLESİ", DistrictId = 2 },
                new Neighborhood() { Id = 33,Name = "ZAFER MAHALLESİ", DistrictId = 2 }
                );

            builder
                .HasOne(x => x.District)
                .WithMany(x => x.Neighborhoods)
                .HasForeignKey(x => x.DistrictId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Navigation(x => x.District).AutoInclude();
        }
    }
}
