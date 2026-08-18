namespace CareerConnect.Application.Features.Jobs.DTOs;

public class CreateJobRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }

    public int MinExperience { get; set; }
    public int MaxExperience { get; set; }
}