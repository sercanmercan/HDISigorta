using HDISigorta.Application.Abstractions.Helper;
using HDISigorta.Application.Repositories.Agreements;
using HDISigorta.Application.Repositories.AppUser;
using HDISigorta.Application.Repositories.Dealers;
using HDISigorta.Application.Repositories.ProductHistory;
using HDISigorta.Application.Repositories.Products;
using HDISigorta.Domain.Entities.Identities;
using HDISigorta.Persistence.Contexts;
using HDISigorta.Persistence.Repositories.Agreements;
using HDISigorta.Persistence.Repositories.AppUser;
using HDISigorta.Persistence.Repositories.Dealers;
using HDISigorta.Persistence.Repositories.Product;
using HDISigorta.Persistence.Repositories.Products;
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
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<HDISigortaDbContext>();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IAgreementReadRepository, AgreementReadRepository>();
            services.AddScoped<IAgreementWriteRepository, AgreementWriteRepository>();
            services.AddScoped<IHelper, Helper.Helper>();
            services.AddScoped<IProductHistoryReadRepository, ProductHistoryReadRepository>();
            services.AddScoped<IDealerReadRepository, DealerReadRepository>();
            services.AddScoped<IDealerWriteRepository, DealerWriteRepository>();
        }
    }
}
