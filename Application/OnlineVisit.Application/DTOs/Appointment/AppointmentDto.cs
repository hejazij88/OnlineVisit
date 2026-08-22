using OnlineVisit.Domain.Enums;

namespace OnlineVisit.Application.DTOs.Appointment;

public class AppointmentDto
{
    public Guid Id { get; set; }

    public Guid DoctorId { get; set; }

    public string DoctorName { get; set; } = null!;

    public Guid PatientId { get; set; }

    public string PatientName { get; set; } = null!;

    public Guid TimeSlotId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public decimal Amount { get; set; }

    public AppointmentStatus Status { get; set; }

    public string? PatientNote { get; set; }

    public string? DoctorNote { get; set; }

    public DateTime CreatedAt { get; set; }
}
