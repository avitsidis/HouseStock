using System.Collections.Generic;

namespace HouseStock.Presentation.Blazor.Shared
{
    public class GetAllCategoriesResponse
    {
        public List<GetAllCategoriesResponseItem> Categories { get; set; }
    }

    public class GetAllCategoriesResponseItem
    {
        public string Name { get; set; }
        public long Id { get; set; }
    }
}
