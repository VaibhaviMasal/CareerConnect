using CareerConnect.Domain.Enums;

namespace CareerConnect.Application.Features.Authentication.DTOs;

public class RegisterRequestDto
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public UserRole Role { get; set; }
}