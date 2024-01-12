using Microsoft.AspNetCore.Mvc;
using RestfulAPIBase.Lib.Auth.Models;

namespace RestfulAPIBase.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login/sample")]
    public IActionResult LoginSample([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (model.Username != "sample" || model.Password != "123") return Unauthorized();
        return Ok();
    }
}
