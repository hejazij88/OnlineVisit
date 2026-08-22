namespace OnlineVisit.Application.DTOs.Doctor;

public class DoctorDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MedicalLicenseNumber { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string Biography { get; set; } = string.Empty;

    public decimal ConsultationFee { get; set; }

    public bool IsActive { get; set; }
}