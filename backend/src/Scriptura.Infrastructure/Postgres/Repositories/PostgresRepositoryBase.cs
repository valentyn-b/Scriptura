namespace Scriptura.Infrastructure.Postgres.Repositories;

internal abstract class PostgresRepositoryBase(ScripturaDbContext dbContext)
{
    protected readonly ScripturaDbContext DbContext = dbContext;
}
