using Accounts.Domain.Models;

namespace Accounts.API.Models;


/// <summary>
/// Represents a registration request for a user in a parking lot system.
/// </summary>
/// <param name="Email"> the user's email address. </param>
/// <param name="Password"> the user's password. </param>
/// <param name="Name"> the user's first name. </param>
/// <param name="LastName"> the user's last name. </param>
/// <param name="Role"> the role of the user upon registration, which can be Owner or Valet. </param>
public record SignUpRequest(string Email,
                            string Password,
                            string Name,
                            string LastName,
                            UserRole Role);
