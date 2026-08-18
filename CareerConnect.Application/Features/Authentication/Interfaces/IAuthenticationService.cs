using CareerConnect.Application.Features.Authentication.DTOs;


namespace CareerConnect.Application.Features.Authentication.Interfaces;

public interface IAuthenticationService
{
    Task<AuthResponseDto> RegisterAsync(
        RegisterRequestDto request);

    Task<AuthResponseDto> LoginAsync(
        LoginRequestDto request);
}