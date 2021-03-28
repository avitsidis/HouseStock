using HouseStock.DataAccess;
using HouseStock.Domain;
using HouseStock.Presentation.Blazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HouseStock.Presentation.Blazor.Server.Controllers
{
    [Route("/product/{productId}/instances")]
    [ApiController]
    public class ProductInstanceController : ControllerBase
    {
        private readonly HouseStockDbContext houseStockDbContext;

        public ProductInstanceController(HouseStockDbContext houseStockDbContext)
        {
            this.houseStockDbContext = houseStockDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<AddProductResponse>> Add([FromRoute]long productId,[FromBody] Shared.AddProductInstanceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var shelf = await houseStockDbContext.Shelves.FindAsync(request.ShelfId);
            if (shelf == null)
            {
                return BadRequest($"Shelf with id {request.ShelfId} does not exist");
            }
            var product = await houseStockDbContext.Products.FindAsync(productId);
            if (product == null)
            {
                return BadRequest($"Product with id {productId} does not exist");
            }
            var instance = product.AddInstance(shelf, new Domain.AddProductInstanceRequest { 
                ExpirationDate = request.ExpirationDate,
                Amount = request.Amount,
                AmountUnit = (Unit)Enum.Parse(typeof(Unit), request.AmountUnit.ToString())
            });
            await houseStockDbContext.SaveChangesAsync();
            return Ok(new AddProductInstanceResponse { ProductInstanceId = instance.Id });
        }

        [HttpPost("/instances/{id}/consume")]
        public async Task<ActionResult<Response<Empty>>> Consume([FromRoute] long id)
        {
            var instance = await houseStockDbContext.ProductInstances.FindAsync(id);
            if (instance == null)
            {
                return BadRequest($"Product instance with id {id} does not exist");
            }
            instance.Consume();
            await houseStockDbContext.SaveChangesAsync();
            return Ok(Response<Empty>.Success(Empty.Instance));
        }

        [HttpGet]
        [Route("/product/all/instances")]
        public async Task<ActionResult<GetInventoryResponse>> GetAll()
        {
            var items = await houseStockDbContext
                .ProductInstances
                .Include(pi => pi.Product)
                .Include(pi => pi.Shelf)
                .Include(pi => pi.Shelf.Room)
                .Include(pi => pi.Product.Category)
                .Where(pi => pi.ConsumedAt == null)
                .ToListAsync();
            return Ok(new GetInventoryResponse {
                Items = items.Select(i => new InventoryItem {
                    Amount = i.Amount,
                    AmountUnit = (AmountUnit)Enum.Parse(typeof(Unit), i.AmountUnit.ToString()),
                    CategoryId = i.Product.Category.Id,
                    CategoryName = i.Product.Category.Name,
                    ExpirationDate = i.ExpirationDate,
                    InventoryDate = i.InventoryDate,
                    ProductId = i.Product.Id,
                    ProductName = i.Product.Name,
                    ProductInstanceId = i.Id,
                    RoomName = i.Shelf.Room.Name,
                    ShelfId = i.Shelf.Id,
                    ShelfName = i.Shelf.Name
                    }).ToList()
                });
        }

    }
}
