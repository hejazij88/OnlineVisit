namespace OnlineVisit.Application.DTOs.DoctorCategory;

public class DoctorCategoryDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }
}