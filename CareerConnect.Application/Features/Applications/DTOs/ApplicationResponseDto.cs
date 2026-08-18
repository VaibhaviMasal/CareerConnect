namespace CareerConnect.Application.Features.Applications.DTOs;

public class ApplicationResponseDto
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public DateTime AppliedAt { get; set; }
    public int Status { get; set; }
}