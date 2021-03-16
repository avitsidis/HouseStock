using HouseStock.DataAccess;
using HouseStock.Domain;
using HouseStock.Presentation.Blazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
                return BadRequest($"Product with id {request.ShelfId} does not exist");
            }
            var instance = product.AddInstance(shelf, new Domain.AddProductInstanceRequest { 
                ExpirationDate = request.ExpirationDate,
                Amount = request.Amount,
                AmountUnit = (Unit)Enum.Parse(typeof(Unit), request.AmountUnit.ToString())
            });
            await houseStockDbContext.SaveChangesAsync();
            return Ok(new AddProductInstanceResponse { ProductInstanceId = instance.Id });
        }


    }
}
