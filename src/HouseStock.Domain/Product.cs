using System.Collections.Generic;

namespace HouseStock.Domain
{
    public class Product : NamedEntity
    {
        public virtual string Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<ProductInstance> Instances { get; set; } = new List<ProductInstance>();

        protected Product()
        {

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
