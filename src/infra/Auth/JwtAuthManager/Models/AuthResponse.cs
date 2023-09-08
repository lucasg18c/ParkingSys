namespace JwtAuthManager.Models;

public class AuthResponse
{
    public string UserId { get; set; }

    public string JwtToken { get; set; }

    public int ExpiresIn { get; set; }
}
