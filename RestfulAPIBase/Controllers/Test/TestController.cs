using Microsoft.AspNetCore.Mvc;

namespace RestfulAPIBase.Controllers.Test;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Status()
    {
        return Ok("API is up!");
    }

    [HttpPost]
    public IActionResult Post([FromQuery] string message)
    {
        return Ok($"Posted message: {message}");
    }
}
