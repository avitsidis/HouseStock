using System.Collections.Generic;

namespace HouseStock.Domain
{
    public class Shelf : NamedEntity
    {
        public IList<ProductInstance> ProductInstances { get; set; }
        public virtual Room Room { get; protected set; }
    }
}
