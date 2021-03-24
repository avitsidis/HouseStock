using Microsoft.AspNetCore.Mvc;

namespace HouseStock.Presentation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok(this.GetType().Assembly.GetName().Version.ToString());
        }
    }
}
