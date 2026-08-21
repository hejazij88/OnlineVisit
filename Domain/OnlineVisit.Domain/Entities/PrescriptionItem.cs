namespace OnlineVisit.Domain.Entities;

public class PrescriptionItem
{
    private PrescriptionItem()
    {
    }

    public PrescriptionItem(
        Guid id,
        Guid prescriptionId,
        string medicineName,
        string dosage,
        string duration,
        string? instructions = null)
    {
        if (id == Guid.Empty)
            throw new ArgumentException(
                "Prescription item Id cannot be empty.",
                nameof(id));

        if (prescriptionId == Guid.Empty)
            throw new ArgumentException(
                "Prescription Id cannot be empty.",
                nameof(prescriptionId));

        if (string.IsNullOrWhiteSpace(medicineName))
            throw new ArgumentException(
                "Medicine name is required.",
                nameof(medicineName));

        if (string.IsNullOrWhiteSpace(dosage))
            throw new ArgumentException(
                "Dosage is required.",
                nameof(dosage));

        if (string.IsNullOrWhiteSpace(duration))
            throw new ArgumentException(
                "Duration is required.",
                nameof(duration));

        Id = id;
        PrescriptionId = prescriptionId;
        MedicineName = medicineName;
        Dosage = dosage;
        Duration = duration;
        Instructions = instructions;
    }

    public Guid Id { get; private set; }

    public Guid PrescriptionId { get; private set; }

    public string MedicineName { get; private set; } = null!;

    public string Dosage { get; private set; } = null!;

    public string Duration { get; private set; } = null!;

    public string? Instructions { get; private set; }

    public Prescription Prescription { get; private set; } = null!;

    public void Update(
        string medicineName,
        string dosage,
        string duration,
        string? instructions)
    {
        if (string.IsNullOrWhiteSpace(medicineName))
            throw new ArgumentException(
                "Medicine name is required.",
                nameof(medicineName));

        if (string.IsNullOrWhiteSpace(dosage))
            throw new ArgumentException(
                "Dosage is required.",
                nameof(dosage));

        if (string.IsNullOrWhiteSpace(duration))
            throw new ArgumentException(
                "Duration is required.",
                nameof(duration));

        MedicineName = medicineName;
        Dosage = dosage;
        Duration = duration;
        Instructions = instructions;
    }
}