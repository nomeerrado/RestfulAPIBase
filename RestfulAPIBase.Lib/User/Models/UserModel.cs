namespace RestfulAPIBase.Lib.User.Models;

public class UserModel
{
    public string Email { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string? PasswordHash { get; set; }

    public string Token { get; set; } = default!;
}
