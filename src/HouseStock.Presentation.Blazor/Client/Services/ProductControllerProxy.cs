using HouseStock.Presentation.Blazor.Shared;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace HouseStock.Presentation.Blazor.Client.Services
{
    public class ProductControllerProxy
    {
        private readonly HttpClient client;
        private readonly ILogger<ProductControllerProxy> logger;

        public ProductControllerProxy(HttpClient client, ILogger<ProductControllerProxy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<GetAllCategoriesResponse> GetAllCategories()
        {
            var response = await client.GetFromJsonAsync<GetAllCategoriesResponse>("category");
            return response;
        }

        public async Task<Response<AddProductResponse>> Add(AddProductRequest roomRequest)
        {
            try
            {
                var response = await client.PostAsJsonAsync("product", roomRequest);
                response.EnsureSuccessStatusCode();
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<AddProductResponse>(responseStream);
                return Response<AddProductResponse>.Success(result);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.Message);
                return Response<AddProductResponse>.Fail("ADD_PRODUCT_ERROR", e);
            }

        }

        public async Task<Response<AddProductInstanceResponse>> Add(long productId, AddProductInstanceRequest addProductInstanceRequest)
        {
            try
            {
                var response = await client.PostAsJsonAsync($"product/{productId}/instances", addProductInstanceRequest);
                response.EnsureSuccessStatusCode();
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<AddProductInstanceResponse>(responseStream);
                return Response<AddProductInstanceResponse>.Success(result);
            }
            catch (System.Exception e)
            {
                return Response<AddProductInstanceResponse>.Fail("ADD_PRODUCT_INSTANCE_ERROR", e);
            }

        }

        public async Task<Response<SearchProductResponse>> Search(string name, int limit = 5)
        {
            try
            {
                var response = await client.GetAsync($"product?partName={name}&limit={limit}");
                response.EnsureSuccessStatusCode();
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<SearchProductResponse>(responseStream,new JsonSerializerOptions() { 
                PropertyNameCaseInsensitive = true
                });
                logger.LogDebug($"result.Products.Count = {result.Products.Count}");
                return Response<SearchProductResponse>.Success(result);
            }
            catch (System.Exception e)
            {
                logger.LogError($"error = {e.Message}");
                return Response<SearchProductResponse>.Fail("SEARCH_PRODUCT_ERROR", e);
            }
        }

        public async Task<Response<GetInventoryResponse>> GetInventory()
        {
            ///product/all/instances
            try
            {
                var response = await client.GetAsync($"product/all/instances");
                response.EnsureSuccessStatusCode();
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<GetInventoryResponse>(responseStream, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
                logger.LogDebug($"result.Items.Count = {result.Items.Count}");
                return Response<GetInventoryResponse>.Success(result);
            }
            catch (System.Exception e)
            {
                logger.LogError($"error = {e.Message}");
                return Response<GetInventoryResponse>.Fail("GET_INVENTORY_ERROR", e);
            }
        }

    }
}
