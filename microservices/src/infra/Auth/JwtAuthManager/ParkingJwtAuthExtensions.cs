using JwtAuthManager.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JwtAuthManager;

public static class ParkingJwtAuthExtensions
{
    public static void AddCustomJwtAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(o =>
        {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.RequireHttpsMetadata = false;
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtTokenHandler.JWT_SECURITY_KEY))
            };
        });
    }

    public static HttpClaims GetClaims(this HttpContext context)
    {
        var claims = context.User.Claims;

        var email = claims
            .FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)
            ?.Value
            ?? throw new ApplicationException("Not authorized");

        var userId = claims
            .FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)
            ?.Value
            ?? throw new ApplicationException("Not authorized");

        var role = claims
            .FirstOrDefault(c => c.Type == "Role")
            ?.Value
            ?? throw new ApplicationException("Not authorized");

        return new HttpClaims(email, userId, int.Parse(role));
    }
}
