namespace CareerConnect.Domain.Entities
{
    public class CandidateProfile
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Skills { get; set; } = string.Empty;
        public int Experience { get; set; }

        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();

        // ✅ ADD THESE (your service needs them)
        public string Education { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public ICollection<Resume> Resumes { get; set; } = new List<Resume>();
    }
}