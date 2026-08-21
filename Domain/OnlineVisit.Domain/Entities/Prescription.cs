using OnlineVisit.Domain.Enums;

namespace OnlineVisit.Domain.Entities;

public class Prescription
{
    private readonly List<PrescriptionItem> _items = new();

    private Prescription()
    {
    }

    public Prescription(
        Guid id,
        Guid doctorId,
        Guid patientId,
        Guid? appointmentId,
        string diagnosis,
        string? notes = null)
    {
        if (id == Guid.Empty)
            throw new ArgumentException(
                "Prescription Id cannot be empty.",
                nameof(id));

        if (doctorId == Guid.Empty)
            throw new ArgumentException(
                "Doctor Id cannot be empty.",
                nameof(doctorId));

        if (patientId == Guid.Empty)
            throw new ArgumentException(
                "Patient Id cannot be empty.",
                nameof(patientId));

        if (string.IsNullOrWhiteSpace(diagnosis))
            throw new ArgumentException(
                "Diagnosis is required.",
                nameof(diagnosis));

        Id = id;
        DoctorId = doctorId;
        PatientId = patientId;
        AppointmentId = appointmentId;
        Diagnosis = diagnosis;
        Notes = notes;

        Status = PrescriptionStatus.Draft;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }

    public Guid DoctorId { get; private set; }

    public Guid PatientId { get; private set; }

    public Guid? AppointmentId { get; private set; }

    public string Diagnosis { get; private set; } = null!;

    public string? Notes { get; private set; }

    public PrescriptionStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? IssuedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public Doctor Doctor { get; private set; } = null!;

    public Patient Patient { get; private set; } = null!;

    public Appointment? Appointment { get; private set; }

    public IReadOnlyCollection<PrescriptionItem> Items =>
        _items.AsReadOnly();

    public void AddItem(
        string medicineName,
        string dosage,
        string duration,
        string? instructions = null)
    {
        if (Status != PrescriptionStatus.Draft)
            throw new InvalidOperationException(
                "Items can only be added to a draft prescription.");

        var item = new PrescriptionItem(
            Guid.NewGuid(),
            Id,
            medicineName,
            dosage,
            duration,
            instructions);

        _items.Add(item);
    }

    public void RemoveItem(Guid itemId)
    {
        if (Status != PrescriptionStatus.Draft)
            throw new InvalidOperationException(
                "Items can only be removed from a draft prescription.");

        var item = _items.FirstOrDefault(x => x.Id == itemId);

        if (item is null)
            throw new InvalidOperationException(
                "Prescription item was not found.");

        _items.Remove(item);
    }

    public void Issue()
    {
        if (Status != PrescriptionStatus.Draft)
            throw new InvalidOperationException(
                "Only draft prescriptions can be issued.");

        if (_items.Count == 0)
            throw new InvalidOperationException(
                "Prescription must contain at least one item.");

        Status = PrescriptionStatus.Issued;
        IssuedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Cancel()
    {
        if (Status == PrescriptionStatus.Cancelled)
            return;

        Status = PrescriptionStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
    }
}