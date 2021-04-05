using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HouseStock.Presentation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public VersionController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public ActionResult<string> Get()
        {
            var version = GetType().Assembly.GetName().Version.ToString();
            var env = webHostEnvironment.EnvironmentName.Substring(0, 3);
            return Ok($"{version}-{env}");
        }
    }
}
