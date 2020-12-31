using HouseStock.DataAccess;
using HouseStock.Domain;
using HouseStock.Presentation.Blazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public ActionResult<GetAllRoomsResponse> GetAll()
        {
            var all = houseStockDbContext.Rooms;
            return Ok(new GetAllRoomsResponse
            {
                Rooms = houseStockDbContext.Rooms.Select(room => new GetAllRoomsResponseItem
                {
                    Id = room.Id,
                    Name = room.Name
                }).ToList()
            });
        }



    }
}
