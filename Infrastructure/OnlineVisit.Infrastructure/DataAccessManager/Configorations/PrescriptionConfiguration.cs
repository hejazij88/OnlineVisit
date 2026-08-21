using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineVisit.Domain.Entities;

namespace OnlineVisit.Infrastructure.DataAccessManager.Configorations;

public class PrescriptionConfiguration
    : IEntityTypeConfiguration<Prescription>
{
    public void Configure(
        EntityTypeBuilder<Prescription> builder)
    {
        builder.ToTable("Prescriptions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Diagnosis)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(x => x.Notes)
            .HasMaxLength(5000);

        builder.Property(x => x.Status)
            .IsRequired();

        builder.HasOne(x => x.Doctor)
            .WithMany(x => x.Prescriptions)
            .HasForeignKey(x => x.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Patient)
            .WithMany(x => x.Prescriptions)
            .HasForeignKey(x => x.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Appointment)
            .WithMany()
            .HasForeignKey(x => x.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}