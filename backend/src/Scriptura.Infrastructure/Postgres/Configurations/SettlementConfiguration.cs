using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scriptura.Domain.Entities.Catalog;

namespace Scriptura.Infrastructure.Postgres.Configurations
{
    public class SettlementConfiguration : IEntityTypeConfiguration<Settlement>
    {
        public void Configure(EntityTypeBuilder<Settlement> builder)
        {
            builder.ToTable("settlements");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.CurrentName)
                .HasColumnName("current_name")
                .IsRequired();

            builder.Property(x => x.Type)
                .HasColumnName("type")
                .HasConversion<string>()
                .IsRequired();

            builder.Property("_alternativeNames")
                .HasColumnName("alternative_names");

            builder.OwnsOne(x => x.ModernAdminDivision, md =>
            {
                md.Property(p => p.Region).HasColumnName("modern_region");
                md.Property(p => p.District).HasColumnName("modern_district");
                md.Property(p => p.Community).HasColumnName("modern_community");
            });

            builder.OwnsOne(x => x.Location, loc =>
            {
                loc.Property(p => p.Latitude).HasColumnName("latitude");
                loc.Property(p => p.Longitude).HasColumnName("longitude");
            });

            builder.OwnsMany(x => x.HistoricalDivisions, hd =>
            {
                hd.ToTable("settlements");
                hd.ToJson("historical_divisions");

                hd.Property(p => p.Governorate).HasJsonPropertyName("governorate");
                hd.Property(p => p.County).HasJsonPropertyName("county");
                hd.Property(p => p.Parish).HasJsonPropertyName("parish");
            });
            
        }
    }
}
