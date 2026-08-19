using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CareerConnect.Domain.Entities;


public class RecruiterProfile
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public string CompanyName { get; set; } = string.Empty;
    public string? CompanyWebsite { get; set; }

    public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
}