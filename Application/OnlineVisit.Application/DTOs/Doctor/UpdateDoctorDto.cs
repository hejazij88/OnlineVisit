namespace OnlineVisit.Application.DTOs.Doctor;

public class UpdateDoctorDto
{
    public Guid CategoryId { get; set; }

    public string MedicalLicenseNumber { get; set; } = null!;

    public string Biography { get; set; } = string.Empty;

    public decimal ConsultationFee { get; set; }
}