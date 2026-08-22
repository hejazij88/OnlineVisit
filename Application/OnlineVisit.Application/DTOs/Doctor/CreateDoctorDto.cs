namespace OnlineVisit.Application.DTOs.Doctor;

public class CreateDoctorDto
{
    public Guid UserId { get; set; }

    public Guid CategoryId { get; set; }

    public string MedicalLicenseNumber { get; set; } = null!;

    public string Biography { get; set; } = string.Empty;

    public decimal ConsultationFee { get; set; }
}