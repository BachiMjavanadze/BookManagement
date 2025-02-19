using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookManagement.Core.DTOs.AuthDTOs;
using BookManagement.Core.Interfaces;
using BookManagement.Core.Models;
using BookManagement.Core.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BookManagement.Infrastructure.Services;

/// <summary>
/// Provides functionality for generating JWT tokens.
/// </summary>
public class JwtTokenService : IJwtTokenService
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenService(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }

    /// <summary>
    /// Generates a JWT token for the specified user.
    /// </summary>
    /// <param name="user">The user for whom to generate the token.</param>
    /// <returns>
    /// An <see cref="AuthResponseDto"/> containing the generated token, the username, and the token's expiration time.
    /// </returns>
    public AuthResponseDto GenerateToken(User user)
    {
        var expiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes);
        var key = Encoding.UTF8.GetBytes(_jwtSettings.Secret);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expiresAt,
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new AuthResponseDto
        {
            Token = tokenHandler.WriteToken(token),
            Username = user.Username,
            ExpiresAt = expiresAt
        };
    }
}
