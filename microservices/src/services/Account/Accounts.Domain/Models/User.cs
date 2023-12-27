namespace Accounts.Domain.Models;

public class User : Entity
{
    public string? Uid { get; set; }

    public required string Name { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required AuthProvider Provider { get; set; }

    public required UserRole Role { get; set; }

    public required string PasswordHash { get; set; }

    public required string PasswordSalt { get; set; }
}
