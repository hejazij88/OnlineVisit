using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineVisit.Domain.Entities;

namespace OnlineVisit.Infrastructure.DataAccessManager.Configorations;

public class PrescriptionItemConfiguration
    : IEntityTypeConfiguration<PrescriptionItem>
{
    public void Configure(
        EntityTypeBuilder<PrescriptionItem> builder)
    {
        builder.ToTable("PrescriptionItems");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.MedicineName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Dosage)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Duration)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Instructions)
            .HasMaxLength(1000);

        builder.HasOne(x => x.Prescription)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.PrescriptionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}