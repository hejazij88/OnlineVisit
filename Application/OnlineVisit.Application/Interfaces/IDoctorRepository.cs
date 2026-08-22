using OnlineVisit.Domain.Entities;

namespace OnlineVisit.Application.Interfaces;

public interface IDoctorRepository : IRepository<Doctor>
{
    Task<Doctor?> GetByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsByMedicalLicenseAsync(
        string medicalLicenseNumber,
        CancellationToken cancellationToken = default);
}