using HouseStock.DataAccess;
using HouseStock.Domain;
using HouseStock.Presentation.Blazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HouseStock.Presentation.Blazor.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private readonly HouseStockDbContext houseStockDbContext;

        public ShelfController(HouseStockDbContext houseStockDbContext)
        {
            this.houseStockDbContext = houseStockDbContext;
        }
        [HttpPost]
        public async Task<ActionResult<AddShelfResponse>> Add([FromBody] AddShelfRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var room = await houseStockDbContext.Rooms.FindAsync(request.RoomId);
            if (room == null)
            {
                return BadRequest($"Room with id {request.RoomId} does not exist");
            }
            var shelf = Shelf.Create(request.ShelfName, room);
            houseStockDbContext.Shelves.Add(shelf);
            await houseStockDbContext.SaveChangesAsync();
            return Ok(new AddShelfResponse { Name = shelf.Name, Id = shelf.Id, RoomId = room.Id });
        }

    }
}
