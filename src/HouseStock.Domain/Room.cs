using System.Collections.Generic;

namespace HouseStock.Domain
{
    public class Room : NamedEntity
    {
        public virtual IList<Shelf> Shelves { get; set; }
    }
}
