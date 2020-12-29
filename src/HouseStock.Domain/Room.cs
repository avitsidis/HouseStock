using CSharpFunctionalExtensions;
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
                Name = name,
                Shelves = new List<Shelf>()
            };
        }

        public virtual IList<Shelf> Shelves { get; set; }
    }
}
