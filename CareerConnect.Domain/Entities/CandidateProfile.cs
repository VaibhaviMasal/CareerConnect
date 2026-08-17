using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CareerConnect.Domain.Entities;


public partial class CandidateProfile
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [StringLength(15)]
    public string? PhoneNumber { get; set; }

    [StringLength(100)]
    public string? Location { get; set; }

    public int ExperienceYears { get; set; }

    [InverseProperty("Candidate")]
    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    [InverseProperty("Candidate")]
    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();

    [ForeignKey("UserId")]
    [InverseProperty("CandidateProfile")]
    public virtual User User { get; set; } = null!;

    [ForeignKey("CandidateProfileId")]
    [InverseProperty("CandidateProfiles")]
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
