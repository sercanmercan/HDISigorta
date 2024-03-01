using HDISigorta.Application.Abstractions.Token;
using HDISigorta.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace HDISigorta.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
