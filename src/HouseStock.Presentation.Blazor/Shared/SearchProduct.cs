using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseStock.Presentation.Blazor.Shared
{

    public class SearchProductResponse
    {
        public List<SearchProductItem> Products { get; set; }
    }

    public class SearchProductItem
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
