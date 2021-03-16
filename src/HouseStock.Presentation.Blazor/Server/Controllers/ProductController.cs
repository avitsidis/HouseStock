using HouseStock.DataAccess;
using HouseStock.Domain;
using HouseStock.Presentation.Blazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HouseStock.Presentation.Blazor.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly HouseStockDbContext houseStockDbContext;

        public ProductController(HouseStockDbContext houseStockDbContext)
        {
            this.houseStockDbContext = houseStockDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<AddProductResponse>> Add([FromBody] AddProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await houseStockDbContext.Categories.FindAsync(request.CategoryId);
            if (category == null)
            {
                return BadRequest($"Category with id {request.CategoryId} does not exist");
            }
            var product = Product.Create(request.Name, request.Description, category);
            houseStockDbContext.Products.Add(product);
            await houseStockDbContext.SaveChangesAsync();
            return Ok(new AddProductResponse { ProductId = product.Id });
        }

        [HttpGet]
        public async Task<ActionResult<SearchProductResponse>> Search([FromQuery] string partName, int limit = 20)
        {
            partName = partName?.ToLower() ?? "";
            var results = await houseStockDbContext.Products
                .Include(p => p.Category)
                .Where(p => p.Name.ToLower().Contains(partName))
                .Take(limit)
                .ToListAsync();
            
          return Ok(new SearchProductResponse { 
                Products = results.Select(r => new SearchProductItem { 
                    Id = r.Id,
                    Description = r.Description,
                    Name = r.Name,
                    CategoryId = r.Category.Id,
                    CategoryName = r.Category.Name
                }).ToList() 
            });
        }


    }
}
