using System;
using System.Collections.Generic;

namespace HouseStock.Presentation.Blazor.Shared
{
    public class GetInventoryResponse
    {
        public List<InventoryItem> Items { get; set; }
    }

    public class InventoryItem
    {
        public long ProductInstanceId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime ExpirationDate { get; set; }

        public decimal Amount { get; set; }
        public AmountUnit AmountUnit { get; set; }
        public DateTime InventoryDate { get; set; }

        public long ShelfId { get; set; }
        public string ShelfName { get; set; }
        public string RoomName { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }


    }
}
