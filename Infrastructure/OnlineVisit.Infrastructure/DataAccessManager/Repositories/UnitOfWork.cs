using OnlineVisit.Application.Interfaces;

namespace OnlineVisit.Infrastructure.DataAccessManager.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly OnlineVisitDbContext _context;

    public UnitOfWork(
        OnlineVisitDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(
            cancellationToken);
    }
}