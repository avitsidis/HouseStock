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

        public async Task<Response<AddRoomResponse>> AddRoom(AddRoomRequest roomRequest)
        {
            try
            {
                var response = await client.PostAsJsonAsync("room", roomRequest);
                response.EnsureSuccessStatusCode();
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<AddRoomResponse>(responseStream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Response<AddRoomResponse>.Success(data);
            }
            catch (System.Exception e)
            {

                return Response<AddRoomResponse>.Fail("ROOM_ADD_ERROR", e);
            }

        }

        public async Task<GetAllRoomsResponse> GetAll()
        {
            var response = await client.GetFromJsonAsync<GetAllRoomsResponse>("room", new JsonSerializerOptions {PropertyNameCaseInsensitive = true });
            return response;
        }

    }
}
