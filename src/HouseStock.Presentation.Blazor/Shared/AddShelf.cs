using System.ComponentModel.DataAnnotations;

namespace HouseStock.Presentation.Blazor.Shared
{
    public class AddShelfRequest
    {
        [Required]
        [StringLength(100)]
        public string ShelfName { get; set; }
        
        [Required]
        [Range(1,long.MaxValue,ErrorMessage ="You must provide a room")]
        public long RoomId { get; set; }
    }

    public class AddShelfResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long RoomId { get; set; }
    }

}
