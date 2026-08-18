using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CareerConnect.Domain.Entities;

public partial class JobApplication
{
    public int Id { get; set; }

    public int CandidateId { get; set; }
    public int JobPostingId { get; set; }
    public int ResumeId { get; set; }

    public int Status { get; set; }

    public DateTime AppliedAt { get; set; }

    // Navigation properties
    public virtual CandidateProfile Candidate { get; set; } = null!;
    public virtual JobPosting JobPosting { get; set; } = null!;
    public virtual Resume Resume { get; set; } = null!;

    public virtual ICollection<InterviewSchedule> InterviewSchedules { get; set; } = new List<InterviewSchedule>();
}