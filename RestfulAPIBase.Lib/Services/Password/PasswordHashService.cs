using Microsoft.Extensions.Configuration;
using SecureIdentity.Password;

namespace RestfulAPIBase.Lib.Services.Password;

public class PasswordHashService
{
    private readonly IConfiguration _configuration;

    public PasswordHashService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string HashPassword(string password)
    {
        return PasswordHasher.Hash(password, privateKey: _configuration.GetSection("PwdPK").Value!);
    }

    public bool VerifyPassword(string hash, string password)
    {
        return PasswordHasher.Verify(hash, password, privateKey: _configuration.GetSection("PwdPK").Value!);
    }
}
