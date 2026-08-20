
namespace CareerConnect.Domain.Entities;

public class Resume
{
    public int Id { get; set; }

    public int CandidateId { get; set; }
    public CandidateProfile Candidate { get; set; } = null!;

    public string FileUrl { get; set; } = string.Empty;

    public bool IsCurrent { get; set; } = true;

    public DateTime UploadedAt { get; set; }

    


    // 🔥 ADD THIS (fixes your error)
    public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
}