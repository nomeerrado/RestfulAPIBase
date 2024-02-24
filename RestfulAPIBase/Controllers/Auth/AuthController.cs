using Microsoft.AspNetCore.Mvc;
using RestfulAPIBase.Lib.Auth.Models;
using RestfulAPIBase.Lib.Auth.UseCases;

namespace RestfulAPIBase.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly Authenticate _authenticate;

    public AuthController(Authenticate authenticate)
    {
        _authenticate = authenticate;
    }

    [HttpPost("login/sample")]
    public IActionResult LoginSample([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = _authenticate.Execute(model);
        if(user == null)
        {
            return Unauthorized();
        }

        return Ok(user);
    }
}
