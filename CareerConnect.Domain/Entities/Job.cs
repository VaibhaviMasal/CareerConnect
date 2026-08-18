using CareerConnect.Domain.Enums;

namespace CareerConnect.Domain.Entities;

public class Job
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Location { get; set; } = null!;

    public decimal Salary { get; set; }

    public int RecruiterId { get; set; }

    public int CreatedBy { get; set; } // Recruiter Id

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}