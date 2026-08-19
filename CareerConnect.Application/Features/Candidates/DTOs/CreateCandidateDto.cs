

namespace CareerConnect.Application.Features.Candidates.DTOs;
public class CreateCandidateDto
{
    public string Skills { get; set; } = string.Empty;
    public int Experience { get; set; }
    public string Education { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}