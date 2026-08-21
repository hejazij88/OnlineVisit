using OnlineVisit.Domain.Entities;
using OnlineVisit.Domain.Enums;

namespace OnlineVisit.Domain.Entities;

public class Appointment
{
    private Appointment()
    {
    }

    public Appointment(
        Guid id,
        Guid doctorId,
        Guid patientId,
        Guid timeSlotId,
        decimal amount,
        string? patientNote = null)
    {
        if (id == Guid.Empty)
            throw new ArgumentException(
                "Appointment Id cannot be empty.",
                nameof(id));

        if (doctorId == Guid.Empty)
            throw new ArgumentException(
                "Doctor Id cannot be empty.",
                nameof(doctorId));

        if (patientId == Guid.Empty)
            throw new ArgumentException(
                "Patient Id cannot be empty.",
                nameof(patientId));

        if (timeSlotId == Guid.Empty)
            throw new ArgumentException(
                "Time slot Id cannot be empty.",
                nameof(timeSlotId));

        if (amount < 0)
            throw new ArgumentException(
                "Amount cannot be negative.",
                nameof(amount));

        Id = id;
        DoctorId = doctorId;
        PatientId = patientId;
        TimeSlotId = timeSlotId;
        Amount = amount;
        PatientNote = patientNote;

        Status = AppointmentStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }

    public Guid DoctorId { get; private set; }

    public Guid PatientId { get; private set; }

    public Guid TimeSlotId { get; private set; }

    public decimal Amount { get; private set; }

    public AppointmentStatus Status { get; private set; }

    public string? PatientNote { get; private set; }

    public string? DoctorNote { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    // Navigation Properties

    public Doctor Doctor { get; private set; } = null!;

    public Patient Patient { get; private set; } = null!;

    public AppointmentTimeSlot TimeSlot { get; private set; } = null!;

    // Domain Behaviors

    public void Confirm()
    {
        if (Status != AppointmentStatus.Pending)
            throw new InvalidOperationException(
                "Only pending appointments can be confirmed.");

        Status = AppointmentStatus.Confirmed;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Complete(string? doctorNote = null)
    {
        if (Status != AppointmentStatus.Confirmed)
            throw new InvalidOperationException(
                "Only confirmed appointments can be completed.");

        Status = AppointmentStatus.Completed;
        DoctorNote = doctorNote;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Cancel()
    {
        if (Status == AppointmentStatus.Completed)
            throw new InvalidOperationException(
                "Completed appointment cannot be cancelled.");

        if (Status == AppointmentStatus.Cancelled)
            return;

        Status = AppointmentStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Reject()
    {
        if (Status != AppointmentStatus.Pending)
            throw new InvalidOperationException(
                "Only pending appointments can be rejected.");

        Status = AppointmentStatus.Rejected;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdatePatientNote(string? patientNote)
    {
        PatientNote = patientNote;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateAmount(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException(
                "Amount cannot be negative.",
                nameof(amount));

        Amount = amount;
        UpdatedAt = DateTime.UtcNow;
    }
}