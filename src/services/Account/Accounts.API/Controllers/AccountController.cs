using Accounts.API.Models;
using Accounts.Domain.Models;
using Accounts.Domain.Repository;
using JwtAuthManager;
using JwtAuthManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly JwtTokenHandler _jwtTokenHandler;
    private readonly IAccountRepository _accountRepository;

    public AccountController(JwtTokenHandler jwtTokenHandler, IAccountRepository accountRepository)
    {
        _jwtTokenHandler = jwtTokenHandler;
        _accountRepository = accountRepository;
    }

    [HttpPost("signin")]
    public async Task<ActionResult<AuthResponse?>> Authenticate([FromBody] AuthRequest request)
    {
        var user = await _accountRepository.FindUser(request.Email, request.Password);

        return GenerateAuthResponse(user);
    }

    [HttpPost("signup")]
    public async Task<ActionResult<AuthResponse?>> SignUp(SignUpRequest request)
    {
        try
        {
            var createdUser = await _accountRepository.CreateUser(
                request.Email,
                request.Password,
                request.Name,
                request.LastName,
                request.Role,
                AuthProvider.Email);

            return GenerateAuthResponse(createdUser);
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message); // todo use exceptions middleware
        }
    }

    private ActionResult<AuthResponse?> GenerateAuthResponse(User? user)
    {
        if (user is null)
        {
            return Unauthorized();
        }

        var authResponse = _jwtTokenHandler.GenerateJwtToken(user.Email, user.Id, user.Role.ToString());

        if (authResponse is null)
        {
            return Unauthorized();
        }

        return authResponse;
    }
}
