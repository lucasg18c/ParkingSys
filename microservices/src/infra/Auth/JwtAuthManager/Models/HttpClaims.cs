namespace JwtAuthManager.Models;

public record HttpClaims(
    string Email,
    string UserId,
    int Role);
