using System;
using System.ComponentModel.DataAnnotations;

namespace HouseStock.Presentation.Blazor.Shared
{
    public class AddProductInstanceRequest
    {
        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [Range(0,long.MaxValue)]
        public decimal Amount { get; set; }
        public AmountUnit AmountUnit { get; set; }

        [Required]
        [Range(1,long.MaxValue,ErrorMessage ="You must provide a shelf")]
        public long ShelfId { get; set; }

    }

    public enum AmountUnit
    {
        Liter,
        Gram,
        Item
    }

    public class AddProductInstanceResponse
    {
        public long ProductInstanceId { get; set; }
    }

}
