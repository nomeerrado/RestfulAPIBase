using Microsoft.AspNetCore.Mvc;

namespace RestfulAPIBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Status()
        {
            return Ok("API is up!");
        }
    }
}
