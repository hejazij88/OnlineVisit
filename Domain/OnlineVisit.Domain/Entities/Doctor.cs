using System.Numerics;

namespace OnlineVisit.Domain.Entities;

public class Doctor
{
    private readonly List<Appointment> _appointments = new();
    private readonly List<Prescription> _prescriptions = new();

    private Doctor()
    {
    }

    public Doctor(
        Guid id,
        Guid userId,
        Guid categoryId,
        string medicalLicenseNumber,
        string biography,
        decimal consultationFee)
    {
        if (id == Guid.Empty)
            throw new ArgumentException(
                "Doctor Id cannot be empty.",
                nameof(id));

        if (userId == Guid.Empty)
            throw new ArgumentException(
                "User Id cannot be empty.",
                nameof(userId));

        if (categoryId == Guid.Empty)
            throw new ArgumentException(
                "Category Id cannot be empty.",
                nameof(categoryId));

        if (string.IsNullOrWhiteSpace(medicalLicenseNumber))
            throw new ArgumentException(
                "Medical license number is required.",
                nameof(medicalLicenseNumber));

        if (consultationFee < 0)
            throw new ArgumentException(
                "Consultation fee cannot be negative.",
                nameof(consultationFee));

        Id = id;
        UserId = userId;
        CategoryId = categoryId;
        MedicalLicenseNumber = medicalLicenseNumber;
        Biography = biography;
        ConsultationFee = consultationFee;

        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public Guid CategoryId { get; private set; }

    public string MedicalLicenseNumber { get; private set; } = null!;

    public string Biography { get; private set; } = string.Empty;

    public decimal ConsultationFee { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public DoctorCategory Category { get; private set; } = null!;

    public IReadOnlyCollection<Appointment> Appointments =>
        _appointments.AsReadOnly();

    public IReadOnlyCollection<Prescription> Prescriptions =>
        _prescriptions.AsReadOnly();

    public void UpdateInformation(
        Guid categoryId,
        string medicalLicenseNumber,
        string biography,
        decimal consultationFee)
    {
        if (categoryId == Guid.Empty)
            throw new ArgumentException(
                "Category Id cannot be empty.",
                nameof(categoryId));

        if (string.IsNullOrWhiteSpace(medicalLicenseNumber))
            throw new ArgumentException(
                "Medical license number is required.",
                nameof(medicalLicenseNumber));

        if (consultationFee < 0)
            throw new ArgumentException(
                "Consultation fee cannot be negative.",
                nameof(consultationFee));

        CategoryId = categoryId;
        MedicalLicenseNumber = medicalLicenseNumber;
        Biography = biography;
        ConsultationFee = consultationFee;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }
}