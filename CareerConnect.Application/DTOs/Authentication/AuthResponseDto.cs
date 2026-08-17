namespace CareerConnect.Application.DTOs.Authentication;

public class AuthResponseDto
{
    public string Token { get; set; } = null!;
    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

}