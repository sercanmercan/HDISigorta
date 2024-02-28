using HDISigorta.Application.Repositories.AppUser;
using HDISigorta.Domain.Entities.Identities;
using HDISigorta.Persistence.Contexts;
using HDISigorta.Persistence.Repositories.AppUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HDISigorta.Persistence
{
    public static class ServiceRegistration
    {
        //IoC Container a gönderilmiş oluyor.
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<HDISigortaDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<HDISigortaDbContext>();

            services.AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}
