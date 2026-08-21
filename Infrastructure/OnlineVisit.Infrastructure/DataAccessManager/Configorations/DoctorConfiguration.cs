using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineVisit.Domain.Entities;

namespace OnlineVisit.Infrastructure.DataAccessManager.Configorations;

public class DoctorConfiguration: IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.MedicalLicenseNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Biography)
            .HasMaxLength(2000);

        builder.Property(x => x.ConsultationFee)
            .HasPrecision(18, 2);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasIndex(x => x.MedicalLicenseNumber)
            .IsUnique();

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Doctors)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.UserId)
            .IsUnique();

        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}