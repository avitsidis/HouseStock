using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace HouseStock.Presentation.Blazor.Client.Services
{
    public class JsonSerializerWrapper
    {
        private readonly static JsonSerializerOptions defaultOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        public static ValueTask<T> DeserializeAsync<T>(Stream utf8Json)
        {
            return JsonSerializer.DeserializeAsync<T>(utf8Json, defaultOptions);
        }
    }
}
