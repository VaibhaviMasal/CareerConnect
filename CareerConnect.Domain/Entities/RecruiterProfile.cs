using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CareerConnect.Domain.Entities;


public partial class RecruiterProfile
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [StringLength(150)]
    public string CompanyName { get; set; } = null!;

    [StringLength(200)]
    public string? CompanyWebsite { get; set; }

    [InverseProperty("Recruiter")]
    public virtual ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();

    [ForeignKey("UserId")]
    [InverseProperty("RecruiterProfile")]
    public virtual User User { get; set; } = null!;
}
