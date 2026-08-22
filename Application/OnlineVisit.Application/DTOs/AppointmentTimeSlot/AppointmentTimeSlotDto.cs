namespace OnlineVisit.Application.DTOs.AppointmentTimeSlot;

public class AppointmentTimeSlotDto
{
    public Guid Id { get; set; }

    public Guid DoctorId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool IsBooked { get; set; }

    public bool IsActive { get; set; }
}