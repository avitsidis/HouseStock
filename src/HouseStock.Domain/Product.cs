using System.Collections.Generic;

namespace HouseStock.Domain
{
    public class Product : NamedEntity
    {
        public virtual string Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<ProductInstance> Instances { get; set; }
    }
}
