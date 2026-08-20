
namespace CareerConnect.Application.Features.Resumes.DTOs;

public class UpdateResumeDto
{
    public int Id { get; set; }
    public string FileUrl { get; set; } = string.Empty;
    public bool IsCurrent { get; set; }
}