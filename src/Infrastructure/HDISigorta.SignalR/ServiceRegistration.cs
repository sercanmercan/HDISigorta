using HDISigorta.Application.Abstractions.Hubs;
using HDISigorta.SignalR.HubService;
using Microsoft.Extensions.DependencyInjection;

namespace HDISigorta.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
            collection.AddTransient<IProductHubService, ProductHubService>();
            collection.AddSignalR();
        }
    }
}
