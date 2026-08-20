namespace CareerConnect.Domain.Entities;

public class CandidateProfile
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;

    // 🔥 ADD THIS (CRITICAL FIX)
    public ICollection<JobApplication> Applications { get; set; }
        = new List<JobApplication>();

    // Existing fields (keep whatever you already had)
    public string Skills { get; set; } = string.Empty;
    public string Experience { get; set; }
    public string Education { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;

    public ICollection<Resume> Resumes { get; set; }
        = new List<Resume>();
}