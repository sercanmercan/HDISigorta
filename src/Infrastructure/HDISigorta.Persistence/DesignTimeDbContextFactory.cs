using HDISigorta.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HDISigorta.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HDISigortaDbContext>
    {
        public HDISigortaDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<HDISigortaDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
