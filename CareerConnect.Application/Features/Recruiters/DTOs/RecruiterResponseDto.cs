
namespace CareerConnect.Application.Features.Recruiters.DTOs;

public class RecruiterResponseDto
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public string CompanyName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}