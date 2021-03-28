using HouseStock.Presentation.Blazor.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace HouseStock.Presentation.Blazor.Client.Services
{
    public class ProductInstanceControllerProxy
    {
        private readonly HttpClient client;
        private readonly ILogger<ProductInstanceControllerProxy> logger;

        public ProductInstanceControllerProxy(HttpClient client, ILogger<ProductInstanceControllerProxy> logger)
        {
            this.client = client;
            this.logger = logger;
        }
        public async Task<Response<Empty>> Consume(long productInstanceId)
        {
            try
            {
                var response = await client.PostAsJsonAsync($"/instances/{productInstanceId}/consume","");
                response.EnsureSuccessStatusCode();
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<Empty>(responseStream);
                return Response<Empty>.Success(result);
            }
            catch (Exception e)
            {
                logger.LogError(e, $"Cannot consume {productInstanceId}");
                return Response<Empty>.Fail("PRODUCT_INSTANCE_CONSUME_ERROR", e);
            }

        }
    }
}
