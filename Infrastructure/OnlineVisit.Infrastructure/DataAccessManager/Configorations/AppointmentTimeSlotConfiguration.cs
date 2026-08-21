using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineVisit.Domain.Entities;

namespace OnlineVisit.Infrastructure.DataAccessManager.Configorations;

public class AppointmentTimeSlotConfiguration
    : IEntityTypeConfiguration<AppointmentTimeSlot>
{
    public void Configure(
        EntityTypeBuilder<AppointmentTimeSlot> builder)
    {
        builder.ToTable("AppointmentTimeSlots");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StartTime)
            .IsRequired();

        builder.Property(x => x.EndTime)
            .IsRequired();

        builder.Property(x => x.IsBooked)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasOne(x => x.Doctor)
            .WithMany()
            .HasForeignKey(x => x.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
            {
                x.DoctorId,
                x.StartTime,
                x.EndTime
            })
            .IsUnique();
    }
}