using System.ComponentModel.DataAnnotations;

namespace CareerConnect.Domain.Entities;

public class CandidateProfile
{
    [Key]
    public int Id { get; set; }

    // FK to User
    public int UserId { get; set; }

    // Navigation
    public User User { get; set; } = null!;

    // ===== BASIC DETAILS =====
    public string? Experience { get; set; }
    public string? Education { get; set; }
    public string? City { get; set; }

    // ===== RELATIONS =====

    // 🔥 MANY-TO-MANY with Skills
    public string? Skills { get; set; }   

    // 🔥 ONE-TO-MANY with Resumes
    public ICollection<Resume> Resumes { get; set; } = new List<Resume>();

    // 🔥 ONE-TO-MANY with Applications (IMPORTANT — you said don’t remove)
    public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
}