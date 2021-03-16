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
        public List<ShelfItem> Shelves { get; set; }
    }

    public class ShelfItem
    {
        public string Name { get; set; }
        public long Id { get; set; }
    }
}
