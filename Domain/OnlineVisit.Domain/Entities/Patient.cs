namespace OnlineVisit.Domain.Entities;

public class Patient
{
    private readonly List<Appointment> _appointments = new();
    private readonly List<Prescription> _prescriptions = new();

    private Patient()
    {
    }

    public Patient(
        Guid id,
        Guid userId,
        DateTime birthDate,
        string? medicalHistory = null)
    {
        if (id == Guid.Empty)
            throw new ArgumentException(
                "Patient Id cannot be empty.",
                nameof(id));

        if (userId == Guid.Empty)
            throw new ArgumentException(
                "User Id cannot be empty.",
                nameof(userId));

        if (birthDate > DateTime.UtcNow)
            throw new ArgumentException(
                "Birth date cannot be in the future.",
                nameof(birthDate));

        Id = id;
        UserId = userId;
        BirthDate = birthDate;
        MedicalHistory = medicalHistory;

        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public DateTime BirthDate { get; private set; }

    public string? MedicalHistory { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public IReadOnlyCollection<Appointment> Appointments =>
        _appointments.AsReadOnly();

    public IReadOnlyCollection<Prescription> Prescriptions =>
        _prescriptions.AsReadOnly();

    public void UpdateInformation(
        DateTime birthDate,
        string? medicalHistory)
    {
        if (birthDate > DateTime.UtcNow)
            throw new ArgumentException(
                "Birth date cannot be in the future.",
                nameof(birthDate));

        BirthDate = birthDate;
        MedicalHistory = medicalHistory;
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