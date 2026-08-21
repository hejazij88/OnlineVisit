using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineVisit.Domain.Entities;

namespace OnlineVisit.Infrastructure.DataAccessManager.Configorations;

public class AppointmentConfiguration
    : IEntityTypeConfiguration<Appointment>
{
    public void Configure(
        EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.PatientNote)
            .HasMaxLength(2000);

        builder.Property(x => x.DoctorNote)
            .HasMaxLength(2000);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasOne(x => x.Doctor)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Patient)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TimeSlot)
            .WithOne(x => x.Appointment)
            .HasForeignKey<Appointment>(x => x.TimeSlotId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.TimeSlotId)
            .IsUnique();
    }
}