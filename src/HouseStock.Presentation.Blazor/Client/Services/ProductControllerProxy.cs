using HouseStock.Presentation.Blazor.Shared;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace HouseStock.Presentation.Blazor.Client.Services
{
    public class ProductControllerProxy
    {
        private readonly HttpClient client;

        public ProductControllerProxy(HttpClient client)
        {
            this.client = client;
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
                return Response<AddProductResponse>.Fail("ADD_PRODUCT_ERROR", e);
            }

        }
    }
}
