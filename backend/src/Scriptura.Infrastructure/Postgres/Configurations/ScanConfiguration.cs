using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scriptura.Domain.Entities.Digitization;

namespace Scriptura.Infrastructure.Postgres.Configurations
{
    public class ScanConfiguration : IEntityTypeConfiguration<Scan>
    {
        public void Configure(EntityTypeBuilder<Scan> builder)
        {
            builder.ToTable("scans");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.ArchivalItemId)
                .HasColumnName("archival_item_id")
                .IsRequired();

            builder.Property(x => x.OrderNumber)
                .HasColumnName("order_number")
                .IsRequired();

            builder.Property(x => x.SourceUrl)
                .HasColumnName("source_url")
                .IsRequired();

            builder.HasIndex(x => x.ArchivalItemId);
        }
    }
}
