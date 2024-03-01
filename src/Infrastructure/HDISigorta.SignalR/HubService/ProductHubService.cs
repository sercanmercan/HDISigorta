using HDISigorta.Application.Abstractions.Hubs;
using HDISigorta.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace HDISigorta.SignalR.HubService
{
    public class ProductHubService : IProductHubService
    {
        private readonly IHubContext<ProductHub> _hubContext;

        public ProductHubService(IHubContext<ProductHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task ProductAddedMessageAsync(string message)
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("signalRSettings.json", optional: true, reloadOnChange: true)
            .Build();
            await _hubContext.Clients.All.SendAsync(config["ProductAddedMessage"], message);
        }
    }
}
