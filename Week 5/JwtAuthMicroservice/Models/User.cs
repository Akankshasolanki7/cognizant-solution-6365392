namespace JwtAuthMicroservice.Models;

public class User
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = "User";
}

public class LoginModel
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
