namespace OnlineVisit.Application.DTOs.Patient;

public class PatientDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string? MedicalHistory { get; set; }

    public bool IsActive { get; set; }
}