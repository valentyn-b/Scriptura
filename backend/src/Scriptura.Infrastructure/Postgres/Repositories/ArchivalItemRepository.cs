using Microsoft.EntityFrameworkCore;
using Scriptura.Domain.Entities.Catalog;
using Scriptura.Domain.Repositories;

namespace Scriptura.Infrastructure.Postgres.Repositories;

internal sealed class ArchivalItemRepository(ScripturaDbContext dbContext) : IArchivalItemRepository
{
    public async Task<ArchivalItem?> GetByIdWithScansAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<ArchivalItem>()
            .Include(x => x.Scans)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task AddAsync(ArchivalItem item, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<ArchivalItem>().AddAsync(item, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}