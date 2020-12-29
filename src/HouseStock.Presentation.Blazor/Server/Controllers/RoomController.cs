using HouseStock.DataAccess;
using HouseStock.Domain;
using HouseStock.Presentation.Blazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HouseStock.Presentation.Blazor.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly HouseStockDbContext houseStockDbContext;

        public RoomController(HouseStockDbContext houseStockDbContext)
        {
            this.houseStockDbContext = houseStockDbContext;
        }
        [HttpPost]
        public async Task<ActionResult<AddRoomResponse>> AddRoom([FromBody] AddRoomRequest roomRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }
            var room = Room.Create(roomRequest.RoomName);
            houseStockDbContext.Rooms.Add(room);
            await houseStockDbContext.SaveChangesAsync();
            return Ok(new AddRoomResponse { RoomName = room.Name, Id = room.Id });
        }

    }
}
