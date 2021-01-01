using HouseStock.DataAccess;
using HouseStock.Presentation.Blazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HouseStock.Presentation.Blazor.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly HouseStockDbContext houseStockDbContext;

        public CategoryController(HouseStockDbContext houseStockDbContext)
        {
            this.houseStockDbContext = houseStockDbContext;
        }

        [HttpGet]
        public ActionResult<GetAllCategoriesResponse> GetAll()
        {
            var all = houseStockDbContext.Categories;
            return Ok(new GetAllCategoriesResponse
            {
                Categories = houseStockDbContext.Categories.Select(category => new GetAllCategoriesResponseItem
                {
                    Id = category.Id,
                    Name = category.Name
                }).ToList()
            });
        }



    }
}
