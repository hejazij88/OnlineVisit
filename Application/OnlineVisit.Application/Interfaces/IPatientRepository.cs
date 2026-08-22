using OnlineVisit.Domain.Entities;

namespace OnlineVisit.Application.Interfaces;

public interface IPatientRepository : IRepository<Patient>
{
    Task<Patient?> GetByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default);
}