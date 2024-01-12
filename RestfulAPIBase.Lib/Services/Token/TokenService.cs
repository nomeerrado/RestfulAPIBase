using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestfulAPIBase.Lib.Services.Token;

public class TokenService
{
    private readonly string _jwtKey = string.Empty;

    public TokenService(IConfiguration configuration)
    {
        _jwtKey = configuration.GetSection("jwtSecKey").Value ?? string.Empty;
    }

    public string GerarToken(string nome, string email)
    {
        var jwtHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GerarSubject(nome, email),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            ),
        };

        return jwtHandler.WriteToken(jwtHandler.CreateToken(tokenDescriptor));
    }

    private static ClaimsIdentity GerarSubject(string nome, string email)
    {
        var claims = new ClaimsIdentity(new Claim[]
        {
        new (ClaimTypes.Name, nome),
        new (ClaimTypes.Email, email),
        });

        return claims;
    }

    public bool TokenValido(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,

                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = true,

                RequireExpirationTime = true,
                RequireSignedTokens = true,
                ClockSkew = TimeSpan.Zero,
            }, out SecurityToken validatedToken);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool TokenValidoVencido(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,

                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = false,

                RequireExpirationTime = true,
                RequireSignedTokens = true,
                ClockSkew = TimeSpan.Zero,
            }, out SecurityToken validatedToken);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
