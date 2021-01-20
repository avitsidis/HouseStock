namespace HouseStock.Domain
{
    public class Category : NamedEntity
    {
        public static readonly Category Food = new Category(1, "Food");
        public static readonly Category Drinks = new Category(2,"Drinks");
        public static readonly Category Hygiene = new Category(3, "Hygiene");
        public static readonly Category Pharmacy = new Category(4, "Pharmacy");
        public static readonly Category Other = new Category(99,"Other");

        protected Category()
        {

        }

        private Category(long id, string name)
        {
            Name = name;
            Id = id;
        }
    }
}
