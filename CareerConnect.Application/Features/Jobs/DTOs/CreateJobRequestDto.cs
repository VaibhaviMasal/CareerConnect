namespace CareerConnect.Application.Features.Jobs.DTOs;

public class CreateJobRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;

    public int MinExperience { get; set; }
    public int MaxExperience { get; set; }

    public DateTime? Deadline { get; set; }
    public bool IsActive { get; set; }
}