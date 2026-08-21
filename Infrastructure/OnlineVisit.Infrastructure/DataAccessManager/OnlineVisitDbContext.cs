using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineVisit.Domain.Entities;

namespace OnlineVisit.Infrastructure.DataAccessManager;

public class OnlineVisitDbContext: IdentityDbContext<
    ApplicationUser,
    IdentityRole<Guid>,
    Guid>
{
    public OnlineVisitDbContext(DbContextOptions<OnlineVisitDbContext> options):base(options)
    {
        
    }


    public DbSet<Doctor> Doctors => Set<Doctor>();

    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<DoctorCategory> DoctorCategories => Set<DoctorCategory>();

    public DbSet<Appointment> Appointments => Set<Appointment>();

    public DbSet<AppointmentTimeSlot> AppointmentTimeSlots => Set<AppointmentTimeSlot>();

    public DbSet<DoctorAvailability> DoctorAvailabilities => Set<DoctorAvailability>();

    public DbSet<Prescription> Prescriptions => Set<Prescription>();

    public DbSet<PrescriptionItem> PrescriptionItems => Set<PrescriptionItem>();



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(OnlineVisitDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}