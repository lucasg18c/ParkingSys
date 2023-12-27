using System.Security.Cryptography;

namespace Accounts.Infrastructure.Security;

public static class PasswordHasher
{
    /// <summary>
    /// Generate random salt
    /// </summary>
    /// <returns></returns>
    public static string GenerateRandomSalt()
    {
        byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
        return Convert.ToBase64String(saltBytes);
    }

    /// <summary>
    /// Generate a password hash using salt
    /// </summary>
    /// <param name="password"></param>
    /// <param name="salt"></param>
    /// <returns></returns>
    public static string HashPassword(string password, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);
        using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256);
        byte[] hashBytes = pbkdf2.GetBytes(32); // 32 bytes = 256 bits
        return Convert.ToBase64String(hashBytes);
    }
 
    /// <summary>
    /// Verify a saved password
    /// </summary>
    /// <param name="passwordToCheck"></param>
    /// <param name="salt"></param>
    /// <param name="hashedPassword"></param>
    /// <returns></returns>
    public static bool VerifyPassword(string passwordToCheck, string salt, string hashedPassword)
    {
        string newHashedPassword = HashPassword(passwordToCheck, salt);
        return newHashedPassword == hashedPassword;
    }
}