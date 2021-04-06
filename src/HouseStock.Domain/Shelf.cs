using System.Collections.Generic;

namespace HouseStock.Domain
{
    public class Shelf : Entity // Should be NamedEntity but we don't use the interface as we want uniqueness on both roomdId and Name
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
        public virtual string Name { get; set; }
    }
}
