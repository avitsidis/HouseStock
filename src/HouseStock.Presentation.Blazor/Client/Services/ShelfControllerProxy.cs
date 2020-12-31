using HouseStock.Presentation.Blazor.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace HouseStock.Presentation.Blazor.Client.Services
{
    public class ShelfControllerProxy
    {
        private readonly HttpClient client;

        public ShelfControllerProxy(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Response<AddShelfResponse>> Add(AddShelfRequest roomRequest)
        {
            try
            {
                var response = await client.PostAsJsonAsync("shelf", roomRequest);
                response.EnsureSuccessStatusCode();
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<AddShelfResponse>(responseStream);
                return Response<AddShelfResponse>.Success(result);
            }
            catch (System.Exception e)
            {
                return Response<AddShelfResponse>.Fail("ADD_SHELF_ERROR", e);
            }
            
        }

    }
}
