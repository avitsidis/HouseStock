using System.Collections.Generic;

namespace HouseStock.Domain
{
    public class Shelf : NamedEntity
    {
        protected Shelf()
        {

        }

        public static Shelf Create(string name, Room room)
        {
            var shelf = new Shelf() { Name = name };
            room.Shelves.Add(shelf);
            return shelf;
        }
        public IList<ProductInstance> ProductInstances { get; set; }
        public virtual Room Room { get; protected set; }
    }
}
