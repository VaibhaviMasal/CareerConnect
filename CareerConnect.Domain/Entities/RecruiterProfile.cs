using System.ComponentModel.DataAnnotations;

namespace CareerConnect.Domain.Entities;

public class RecruiterProfile
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? CompanyName { get; set; }

    public string? Position { get; set; }   
    public string? City { get; set; }     

    // Navigation
    public User User { get; set; }

    public List<JobPosting> JobPostings { get; set; } = new();
}