using Microsoft.EntityFrameworkCore;
using OnlineVisit.Application.Interfaces;
using OnlineVisit.Domain.Entities;

namespace OnlineVisit.Infrastructure.DataAccessManager.Repositories;

public class PatientRepository
    : Repository<Patient>, IPatientRepository
{
    public PatientRepository(
        OnlineVisitDbContext context)
        : base(context)
    {
    }

    public async Task<Patient?> GetByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
            .FirstOrDefaultAsync(
                x => x.UserId == userId,
                cancellationToken);
    }
}
