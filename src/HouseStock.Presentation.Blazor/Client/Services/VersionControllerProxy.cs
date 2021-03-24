using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace HouseStock.Presentation.Blazor.Client.Services
{
    public class VersionControllerProxy
    {
        private HttpClient client;
        private ILogger<ProductControllerProxy> logger;

        private string serverVersion = null;

        public VersionControllerProxy(HttpClient client, ILogger<ProductControllerProxy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<string> GetServerVersion()
        {
            if (serverVersion == null)
            {
                var response = await client.GetAsync("version");
                response.EnsureSuccessStatusCode();
                serverVersion = await response.Content.ReadAsStringAsync();
                logger.LogInformation("Loaded Server version {version}", serverVersion);
            }
            return serverVersion;
        }
    }
}
