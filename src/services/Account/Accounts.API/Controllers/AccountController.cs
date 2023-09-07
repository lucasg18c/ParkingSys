using JwtAuthManager;
using JwtAuthManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly JwtTokenHandler _jwtTokenHandler;

    public AccountController(JwtTokenHandler jwtTokenHandler)
    {
        _jwtTokenHandler = jwtTokenHandler;
    }

    [HttpPost]
    public ActionResult<AuthResponse?> Authenticate([FromBody] AuthRequest authenticationRequest)
    {
        var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(authenticationRequest);
        if (authenticationResponse == null) return Unauthorized();
        return authenticationResponse;
    }
}
