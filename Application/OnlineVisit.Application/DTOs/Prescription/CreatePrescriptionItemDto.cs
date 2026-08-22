namespace OnlineVisit.Application.DTOs.Prescription;

public class CreatePrescriptionItemDto
{
    public string MedicineName { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public string? Instructions { get; set; }
}