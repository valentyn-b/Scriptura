using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scriptura.Domain.Entities.Catalog;

namespace Scriptura.Infrastructure.Postgres.Configurations
{
    public class ArchivalItemConfiguration : IEntityTypeConfiguration<ArchivalItem>
    {
        public void Configure(EntityTypeBuilder<ArchivalItem> builder)
        {
            builder.ToTable("archival_items");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .IsRequired();

            builder.Property(x => x.Type)
                .HasColumnName("type")
                .HasConversion<string>()
                .IsRequired();

            builder.Property("_settlementIds")
                .HasColumnName("settlement_ids");

            builder.OwnsOne(x => x.Signature, sig =>
            {
                sig.Property(p => p.ArchiveCode).HasColumnName("archive_code");
                sig.Property(p => p.Fond).HasColumnName("fond");
                sig.Property(p => p.Inventory).HasColumnName("inventory");
                sig.Property(p => p.ItemNumber).HasColumnName("item_number");

                sig.HasIndex(p => new { p.ArchiveCode, p.Fond, p.Inventory, p.ItemNumber }).IsUnique();
            });

            builder.OwnsOne(x => x.CoveredYears, years =>
            {
                years.Property(p => p.StartYear).HasColumnName("start_year");
                years.Property(p => p.EndYear).HasColumnName("end_year");
            });

            builder.Metadata.FindNavigation(nameof(ArchivalItem.Scans))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(x => x.Scans)
                .WithOne()
                .HasForeignKey(x => x.ArchivalItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
