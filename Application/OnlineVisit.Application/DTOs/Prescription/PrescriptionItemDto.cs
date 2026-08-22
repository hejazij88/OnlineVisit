namespace OnlineVisit.Application.DTOs.Prescription;

public class PrescriptionItemDto
{
    public Guid Id { get; set; }

    public string MedicineName { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public string? Instructions { get; set; }
}