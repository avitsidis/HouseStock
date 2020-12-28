using System;

namespace HouseStock.Domain
{
    public class ProductInstance : Entity
    {
        public virtual DateTime ExpirationDate { get; set; }
        public virtual Shelf Shelf { get; set; }
        public virtual Product Product { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual Unit AmountUnit { get; set; }
    }
}
