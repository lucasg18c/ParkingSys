using Accounts.Domain.Models;
using Accounts.Domain.Repository;
using Accounts.Infrastructure.Security;

namespace Accounts.Infrastructure.Repository;


public class AccountRepository : IAccountRepository
{
    private readonly ICollection<User> users = new List<User>();

    public AccountRepository()
    {
        var salt1 = PasswordHasher.GenerateRandomSalt();
        var salt2 = PasswordHasher.GenerateRandomSalt();

        users.Add(new User
        {
            Id = "4b2e16d9-cfe7-4f24-b840-0f71f7dc2c9e",
            Email = "lucasg18c@gmail.com",
            Name = "Lucas",
            LastName = "Slavik",
            Provider = AuthProvider.Email,
            PasswordHash = PasswordHasher.HashPassword("1234", salt1),
            PasswordSalt = salt1,
            Role = UserRole.Owner
        });

        users.Add(new User
        {
            Id = "66078ba3-04cd-464f-a07a-3ac5ae35f272",
            Email = "pepe@gmail.com",
            Name = "Pepe",
            LastName = "Pipo",
            Provider = AuthProvider.Email,
            PasswordHash = PasswordHasher.HashPassword("pepexd", salt2),
            PasswordSalt = salt2,
            Role = UserRole.Owner
        });
    }

    /// <inheritdoc/>
    public async Task<User?> CreateUser(
        string email,
        string password,
        string name,
        string lastName,
        UserRole role,
        AuthProvider provider)
    {
        await Task.CompletedTask;

        if (users.FirstOrDefault(u => u.Email == email) is not null)
        {
            throw new ApplicationException("User already exists.");
        }

        var salt = PasswordHasher.GenerateRandomSalt();
        var created = new User
        {
            Email = email,
            Name = name,
            LastName = lastName,
            Provider = provider,
            PasswordHash = PasswordHasher.HashPassword(password, salt),
            PasswordSalt = salt,
            Role = role
        };

        users.Add(created);

        return created;
    }

    /// <inheritdoc/>
    public async Task<User?> FindUser(string email, string password)
    {
        await Task.CompletedTask;

        var user = users.FirstOrDefault(u => u.Email == email);

        if (user is null)
        {
            return null;
        }

        var verified = PasswordHasher.VerifyPassword(password, user.PasswordSalt, user.PasswordHash);

        return verified ? user : null; // TODO: return an account, hide password & salt fields
    }
}
