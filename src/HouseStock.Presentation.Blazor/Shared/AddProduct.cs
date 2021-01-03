using System.ComponentModel.DataAnnotations;

namespace HouseStock.Presentation.Blazor.Shared
{
    public class AddProductRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(1,long.MaxValue,ErrorMessage ="You must provide a room")]
        public long CategoryId { get; set; }
    }

    public class AddProductResponse
    {
        public long ProductId { get; set; }
    }

}
