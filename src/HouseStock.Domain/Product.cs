using System.Collections.Generic;

namespace HouseStock.Domain
{
    public class Product : NamedEntity
    {
        public virtual string Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<ProductInstance> Instances { get; protected set; } = new List<ProductInstance>();

        protected Product()
        {

        }

        public ProductInstance AddInstance(Shelf shelf, AddProductInstanceRequest info)
        {
            var newInstance = new ProductInstance { 
                Product = this,
                Shelf = shelf,
                Amount = info.Amount,
                AmountUnit = info.AmountUnit,
                ExpirationDate = info.ExpirationDate
            };

            Instances.Add(newInstance);
            return newInstance;
        }
        public static Product Create(string name, string description, Category category)
        {
            return new Product { 
                Description = description,
                Name = name,
                Category = category
            };
        }
    }
}
