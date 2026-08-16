using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CareerConnect.Infrastructure.Persistence.Entities;

[Index("CandidateId", Name = "IX_Applications_CandidateId")]
[Index("JobPostingId", Name = "IX_Applications_JobPostingId")]
[Index("CandidateId", "JobPostingId", Name = "UQ_Candidate_Job", IsUnique = true)]
public partial class Application
{
    [Key]
    public int Id { get; set; }

    public int CandidateId { get; set; }

    public int JobPostingId { get; set; }

    public int ResumeId { get; set; }

    public int Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime AppliedAt { get; set; }

    [ForeignKey("CandidateId")]
    [InverseProperty("Applications")]
    public virtual CandidateProfile Candidate { get; set; } = null!;

    [InverseProperty("Application")]
    public virtual ICollection<InterviewSchedule> InterviewSchedules { get; set; } = new List<InterviewSchedule>();

    [ForeignKey("JobPostingId")]
    [InverseProperty("Applications")]
    public virtual JobPosting JobPosting { get; set; } = null!;

    [ForeignKey("ResumeId")]
    [InverseProperty("Applications")]
    public virtual Resume Resume { get; set; } = null!;
}
