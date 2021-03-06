﻿using System;

namespace HouseStock.Domain
{
    public class ProductInstance : Entity
    {
        public ProductInstance()
        {
            InventoryDate = DateTime.Now;
        }
        public virtual DateTime InventoryDate { get; set; }
        public virtual DateTime ExpirationDate { get; set; }
        public virtual Shelf Shelf { get; set; }
        public virtual Product Product { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual Unit AmountUnit { get; set; }
        public virtual DateTime? ConsumedAt { get; set; }

        public void Consume()
        {
            ConsumedAt = DateTime.Now;
        }

    }
}
