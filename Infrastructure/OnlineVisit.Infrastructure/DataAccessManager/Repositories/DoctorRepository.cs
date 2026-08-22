using Microsoft.EntityFrameworkCore;
using OnlineVisit.Application.Interfaces;
using OnlineVisit.Domain.Entities;

namespace OnlineVisit.Infrastructure.DataAccessManager.Repositories;

public class DoctorRepository
    : Repository<Doctor>, IDoctorRepository
{
    public DoctorRepository(
        OnlineVisitDbContext context)
        : base(context)
    {
    }

    public async Task<Doctor?> GetByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
            .FirstOrDefaultAsync(
                x => x.UserId == userId,
                cancellationToken);
    }

    public async Task<bool> ExistsByMedicalLicenseAsync(
        string medicalLicenseNumber,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AnyAsync(
                x => x.MedicalLicenseNumber == medicalLicenseNumber,
                cancellationToken);
    }
}