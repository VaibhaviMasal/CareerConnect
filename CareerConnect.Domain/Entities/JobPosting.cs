using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CareerConnect.Domain.Entities;


public partial class JobPosting
{
    [Key]
    public int Id { get; set; }

    public int RecruiterId { get; set; }

    [StringLength(150)]
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    [StringLength(100)]
    public string Location { get; set; } = null!;

    public int MinExperience { get; set; }

    public int MaxExperience { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Deadline { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public bool IsActive { get; set; }

    [InverseProperty("JobPosting")]
    public virtual ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();

    [ForeignKey("RecruiterId")]
    [InverseProperty("JobPostings")]
    public virtual RecruiterProfile Recruiter { get; set; } = null!;

    [ForeignKey("JobPostingId")]
    [InverseProperty("JobPostings")]
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
