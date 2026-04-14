using Scriptura.Domain.Entities.Catalog;

namespace Scriptura.Domain.Repositories
{
    public interface IArchivalItemRepository
    {
        Task<ArchivalItem?> GetByIdWithScansAsync(Guid id, CancellationToken cancellationToken = default);

        Task AddAsync(ArchivalItem item, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
