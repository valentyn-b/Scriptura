using Microsoft.EntityFrameworkCore;

namespace Scriptura.Infrastructure.Postgres
{
    public class ScripturaDbContext(DbContextOptions<ScripturaDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScripturaDbContext).Assembly);
        }
    }
}
