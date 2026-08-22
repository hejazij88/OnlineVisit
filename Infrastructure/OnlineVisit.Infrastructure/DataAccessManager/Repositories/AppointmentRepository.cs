using Microsoft.EntityFrameworkCore;
using OnlineVisit.Application.Interfaces;
using OnlineVisit.Domain.Entities;

namespace OnlineVisit.Infrastructure.DataAccessManager.Repositories;

public class AppointmentRepository
    : Repository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(
        OnlineVisitDbContext context)
        : base(context)
    {
    }

    public async Task<Appointment?> GetByTimeSlotIdAsync(
        Guid timeSlotId,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
            .FirstOrDefaultAsync(
                x => x.TimeSlotId == timeSlotId,
                cancellationToken);
    }

    public async Task<bool> HasAppointmentForTimeSlotAsync(
        Guid timeSlotId,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AnyAsync(
                x => x.TimeSlotId == timeSlotId,
                cancellationToken);
    }

    public async Task<IReadOnlyList<Appointment>>
        GetDoctorAppointmentsAsync(
            Guid doctorId,
            CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AsNoTracking()
            .Where(x => x.DoctorId == doctorId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Appointment>>
        GetPatientAppointmentsAsync(
            Guid patientId,
            CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AsNoTracking()
            .Where(x => x.PatientId == patientId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);
    }
}