using CareerConnect.Application.DTOs.Authentication;
using CareerCOnnect.Application.DTOs.AUthentication;

namespace CareerConnect.Application.Interfaces;

public interface IAuthenticationService
{
    Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);
    Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
}