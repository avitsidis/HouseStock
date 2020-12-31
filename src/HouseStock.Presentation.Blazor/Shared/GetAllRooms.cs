using System.Collections.Generic;

namespace HouseStock.Presentation.Blazor.Shared
{
    public class GetAllRoomsResponse
    {
        public List<GetAllRoomsResponseItem> Rooms { get; set; }
    }

    public class GetAllRoomsResponseItem
    {
        public string Name { get; set; }
        public long Id { get; set; }
    }
}
