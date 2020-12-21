using Microsoft.AspNetCore.Mvc;

namespace HouseStock.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Ok");
        }
    }
}
