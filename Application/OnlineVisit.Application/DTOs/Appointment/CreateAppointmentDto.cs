namespace OnlineVisit.Application.DTOs.Appointment;

public class CreateAppointmentDto
{
    public Guid DoctorId { get; set; }

    public Guid TimeSlotId { get; set; }

    public string? PatientNote { get; set; }
}
