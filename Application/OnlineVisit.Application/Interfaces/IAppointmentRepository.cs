using OnlineVisit.Domain.Entities;

namespace OnlineVisit.Application.Interfaces;

public interface IAppointmentRepository
    : IRepository<Appointment>
{
    Task<Appointment?> GetByTimeSlotIdAsync(
        Guid timeSlotId,
        CancellationToken cancellationToken = default);

    Task<bool> HasAppointmentForTimeSlotAsync(
        Guid timeSlotId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Appointment>> GetDoctorAppointmentsAsync(
        Guid doctorId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Appointment>> GetPatientAppointmentsAsync(
        Guid patientId,
        CancellationToken cancellationToken = default);
}