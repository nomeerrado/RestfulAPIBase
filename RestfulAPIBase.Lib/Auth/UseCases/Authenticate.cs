using RestfulAPIBase.Lib.Auth.Models;
using RestfulAPIBase.Lib.Services.Password;
using RestfulAPIBase.Lib.Services.Token;
using RestfulAPIBase.Lib.User.Models;

namespace RestfulAPIBase.Lib.Auth.UseCases;

public class Authenticate
{
    private readonly TokenService _tokenService;
    private readonly PasswordHashService _passwordHashService;

    public Authenticate(TokenService tokenService, PasswordHashService passwordHashService)
    {
        _tokenService = tokenService;
        _passwordHashService = passwordHashService;
    }

    public UserModel? Execute(LoginModel model)
    {
        if (model.Username != "sample")
        {
            return null;
        }

        var user = new UserModel
        {
            Email = "sample@sample.com",
            Name = "sample",
            PasswordHash = _passwordHashService.HashPassword("123"),
        };

        if (!_passwordHashService.VerifyPassword(user.PasswordHash, model.Password))
        {
            return null;
        }

        var token = _tokenService.GerarToken(user.Name, user.Email);
        user.Token = token;
        user.PasswordHash = null;

        return user;
    }
}
