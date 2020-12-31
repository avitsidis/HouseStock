using HouseStock.Presentation.Blazor.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace HouseStock.Presentation.Blazor.Client.Services
{
    public class RoomControllerProxy
    {
        private readonly HttpClient client;

        public RoomControllerProxy(HttpClient client)
        {
            this.client = client;
        }

        public async Task<AddRoomResponse> AddRoom(AddRoomRequest roomRequest)
        {
            var response = await client.PostAsJsonAsync("room", roomRequest);
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<AddRoomResponse>(responseStream);
        }

        public async Task<GetAllRoomsResponse> GetAll()
        {
            var response = await client.GetFromJsonAsync<GetAllRoomsResponse>("room");
            return response;
        }

    }
}
