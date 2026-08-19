using System.ComponentModel.DataAnnotations;

namespace CareerConnect.Domain.Entities;

public class Skill
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // MANY-TO-MANY
    public ICollection<CandidateProfile> CandidateProfiles { get; set; } = new List<CandidateProfile>();

    public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
}