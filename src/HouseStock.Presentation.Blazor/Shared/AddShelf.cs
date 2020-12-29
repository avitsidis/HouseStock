namespace HouseStock.Presentation.Blazor.Shared
{
    public class AddShelfRequest
    {
        public string ShelfName { get; set; }
        public long RoomId { get; set; }
    }

    public class AddShelfResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long RoomId { get; set; }
    }

}
