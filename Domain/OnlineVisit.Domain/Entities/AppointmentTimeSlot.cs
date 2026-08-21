namespace OnlineVisit.Domain.Entities;

public class AppointmentTimeSlot
{
    private AppointmentTimeSlot()
    {
    }

    public AppointmentTimeSlot(
        Guid id,
        Guid doctorId,
        DateTime startTime,
        DateTime endTime)
    {
        if (id == Guid.Empty)
            throw new ArgumentException(
                "Time slot Id cannot be empty.",
                nameof(id));

        if (doctorId == Guid.Empty)
            throw new ArgumentException(
                "Doctor Id cannot be empty.",
                nameof(doctorId));

        if (startTime >= endTime)
            throw new ArgumentException(
                "Start time must be before end time.");

        Id = id;
        DoctorId = doctorId;
        StartTime = startTime;
        EndTime = endTime;

        IsBooked = false;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }

    public Guid DoctorId { get; private set; }

    public DateTime StartTime { get; private set; }

    public DateTime EndTime { get; private set; }

    public bool IsBooked { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public Doctor Doctor { get; private set; } = null!;

    public Appointment? Appointment { get; private set; }

    public void Book()
    {
        if (!IsActive)
            throw new InvalidOperationException(
                "This time slot is not active.");

        if (IsBooked)
            throw new InvalidOperationException(
                "This time slot is already booked.");

        IsBooked = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Release()
    {
        if (!IsBooked)
            return;

        IsBooked = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        if (IsBooked)
            throw new InvalidOperationException(
                "A booked time slot cannot be deactivated.");

        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }
}