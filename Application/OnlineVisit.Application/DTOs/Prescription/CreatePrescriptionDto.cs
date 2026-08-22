namespace OnlineVisit.Application.DTOs.Prescription;

public class CreatePrescriptionDto
{
    public Guid PatientId { get; set; }

    public Guid? AppointmentId { get; set; }

    public string Diagnosis { get; set; } = null!;

    public string? Notes { get; set; }

    public List<CreatePrescriptionItemDto> Items { get; set; } = [];
}