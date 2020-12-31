using System.ComponentModel.DataAnnotations;

namespace HouseStock.Presentation.Blazor.Shared
{
    public class AddRoomRequest
    {
        [Required]
        [StringLength(100)]
        public string RoomName { get; set; }
    }
    public class AddRoomResponse
    {
        public long Id { get; set; }
        public string RoomName { get; set; }
    }


}
