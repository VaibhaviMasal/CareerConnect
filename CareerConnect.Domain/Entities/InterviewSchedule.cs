namespace CareerConnect.Domain.Entities;

public class InterviewSchedule
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }
    public JobApplication Application { get; set; }

    public DateTime ScheduledAt { get; set; }

    public string Mode { get; set; } // Online / Offline

    public string? MeetingLink { get; set; }

    public string Status { get; set; } = "Scheduled";
    // Scheduled / Completed / Cancelled

    public DateTime CreatedAt { get; set; }
}