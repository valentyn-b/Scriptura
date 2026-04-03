using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class ScripturaDbInitializer
    {
        public static void Initialize(ScripturaDbContext context)
        {
            if (context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                context.Database.Migrate();
            }

            // SeedDatabase(context);
        }

        public static void SeedDatabase(ScripturaDbContext context)
        {

        }
    }
}
