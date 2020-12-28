using HouseStock.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace HouseStock.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly HouseStockDbContext dbContext;

        public HealthController(HouseStockDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult<string> Get()
        {
            dbContext.Database.CanConnect();
            return Ok("Ok");
        }
    }
}
