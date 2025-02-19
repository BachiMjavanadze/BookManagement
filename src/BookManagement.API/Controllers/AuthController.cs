using BookManagement.API.Models;
using BookManagement.Core.DTOs.AuthDTOs;
using BookManagement.Core.Interfaces;
using BookManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookManagement.API.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthController(IUserRepository userRepository, IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    /// <summary>
    /// Registers a new user in the system.
    /// </summary>
    /// <param name="registerDto">The user registration data</param>
    /// <returns>JWT token with user information</returns>
    /// <response code="200">Returns the JWT token</response>
    /// <response code="409">If username is already taken</response>
    [HttpPost("register")]
    [SwaggerOperation(
        Summary = "Register a new user",
        Description = "Creates a new user account and returns JWT token"
    )]
    [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<AuthResponseDto>> Register([FromBody] UserRegisterDto registerDto)
    {
        var existingUser = await _userRepository.GetByUsernameAsync(registerDto.Username);

        if (existingUser != null)
        {
            return Conflict("Username is already taken");
        }

        var user = new User
        {
            Username = registerDto.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password)
        };

        user = await _userRepository.CreateAsync(user);
        var response = _jwtTokenService.GenerateToken(user);
        return Ok(response);
    }

    /// <summary>
    /// Authenticates a user and returns a JWT token.
    /// </summary>
    /// <param name="loginDto">The login credentials</param>
    /// <returns>JWT token with user information</returns>
    /// <response code="200">Returns the JWT token</response>
    /// <response code="401">If credentials are invalid</response>
    [HttpPost("login")]
    [SwaggerOperation(
        Summary = "Login to the system",
        Description = "Authenticates user credentials and returns JWT token"
    )]
    [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] UserLoginDto loginDto)
    {
        var user = await _userRepository.GetByUsernameAsync(loginDto.Username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
        {
            return Unauthorized("Invalid username or password.");
        }

        var response = _jwtTokenService.GenerateToken(user);
        return Ok(response);
    }
}
