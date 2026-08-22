using OnlineVisit.Domain.Enums;

namespace OnlineVisit.Application.DTOs.Prescription;

public class PrescriptionDto
{
    public Guid Id { get; set; }

    public Guid DoctorId { get; set; }

    public string DoctorName { get; set; } = null!;

    public Guid PatientId { get; set; }

    public string PatientName { get; set; } = null!;

    public Guid? AppointmentId { get; set; }

    public string Diagnosis { get; set; } = null!;

    public string? Notes { get; set; }

    public PrescriptionStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? IssuedAt { get; set; }

    public List<PrescriptionItemDto> Items { get; set; } = [];
}