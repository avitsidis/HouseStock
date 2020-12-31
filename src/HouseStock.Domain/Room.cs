using System.Collections.Generic;

namespace HouseStock.Domain
{
    public class Room : NamedEntity
    {
        protected Room()
        {

        }

        public static Room Create(string name)
        {
            return new Room
            {
                Name = name
            };
        }

        public virtual IList<Shelf> Shelves { get; set; } = new List<Shelf>();
    }
}
