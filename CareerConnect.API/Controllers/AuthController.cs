using CareerConnect.Application.DTOs.Authentication;
using CareerConnect.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CareerConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterRequestDto request)
    {
        try
        {
            var response = await _authenticationService
                .RegisterAsync(request);

            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequestDto request)
    {
        try
        {
            var response = await _authenticationService
                .LoginAsync(request);

            return Ok(response);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new
            {
                message = ex.Message
            });
        }
    }
}