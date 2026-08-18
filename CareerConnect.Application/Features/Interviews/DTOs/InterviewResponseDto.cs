namespace CareerConnect.Application.Features.Interviews.DTOs;

public class InterviewResponseDto
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public DateTime ScheduledAt { get; set; }
    public string Mode { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;

}