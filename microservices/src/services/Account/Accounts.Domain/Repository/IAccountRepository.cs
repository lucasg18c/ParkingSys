using Accounts.Domain.Models;

namespace Accounts.Domain.Repository;

/// <summary>
/// 
/// </summary>
public interface IAccountRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <param name="name"></param>
    /// <param name="lastName"></param>
    /// <param name="role"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    Task<User?> CreateUser(string email,
                           string password,
                           string name,
                           string lastName,
                           UserRole role,
                           AuthProvider provider);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<User?> FindUser(string email, string password);
}
