using HDISigorta.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HDISigorta.Persistence
{
    public static class ServiceRegistration
    {
        //IoC Container a gönderilmiş oluyor.
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<HDISigortaDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            
        }
    }
}
