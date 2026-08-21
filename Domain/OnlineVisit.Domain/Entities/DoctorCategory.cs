namespace OnlineVisit.Domain.Entities;

public class DoctorCategory
{
    private readonly List<Doctor> _doctors = new();

    private DoctorCategory()
    {
    }

    public DoctorCategory(
        Guid id,
        string name,
        string? description = null)
    {
        if (id == Guid.Empty)
            throw new ArgumentException(
                "Category Id cannot be empty.",
                nameof(id));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Category name is required.",
                nameof(name));

        Id = id;
        Name = name;
        Description = description;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public IReadOnlyCollection<Doctor> Doctors =>
        _doctors.AsReadOnly();

    public void Update(
        string name,
        string? description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Category name is required.",
                nameof(name));

        Name = name;
        Description = description;
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