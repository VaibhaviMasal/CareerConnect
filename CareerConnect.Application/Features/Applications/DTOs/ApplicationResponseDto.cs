namespace CareerConnect.Application.Features.Applications.DTOs;

public class ApplicationResponseDto
{
    public int Id { get; set; }

    public int JobId { get; set; }

    public int CandidateId { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime AppliedAt { get; set; }
}