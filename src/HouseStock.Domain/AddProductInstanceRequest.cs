using System;

namespace HouseStock.Domain
{
    public class AddProductInstanceRequest
    {
        public virtual DateTime ExpirationDate { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual Unit AmountUnit { get; set; }
    }
}
