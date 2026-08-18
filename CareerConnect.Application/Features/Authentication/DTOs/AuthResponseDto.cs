namespace CareerConnect.Application.Features.Authentication.DTOs;

public class AuthResponseDto
{
    public string AccessToken { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;
}