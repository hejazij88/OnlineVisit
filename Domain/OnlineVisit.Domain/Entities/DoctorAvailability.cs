namespace OnlineVisit.Domain.Entities;

public class DoctorAvailability
{
    private DoctorAvailability()
    {
    }

    public DoctorAvailability(
        Guid id,
        Guid doctorId,
        DayOfWeek dayOfWeek,
        TimeSpan startTime,
        TimeSpan endTime)
    {
        if (id == Guid.Empty)
            throw new ArgumentException(
                "Availability Id cannot be empty.",
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
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        EndTime = endTime;

        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }

    public Guid DoctorId { get; private set; }

    public DayOfWeek DayOfWeek { get; private set; }

    public TimeSpan StartTime { get; private set; }

    public TimeSpan EndTime { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public Doctor Doctor { get; private set; } = null!;

    public void Update(
        DayOfWeek dayOfWeek,
        TimeSpan startTime,
        TimeSpan endTime)
    {
        if (startTime >= endTime)
            throw new ArgumentException(
                "Start time must be before end time.");

        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        EndTime = endTime;
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