namespace CareerConnect.Application.Features.Interviews.DTOs;

public class ScheduleInterviewRequestDto
{
    public int ApplicationId { get; set; }
    public DateTime ScheduledAt { get; set; }
    public string Mode { get; set; }
    public string? MeetingLink { get; set; }
}