using System;
using System.Collections.Generic;

namespace CareerConnect.Domain.Entities;

public class User
{
    public int Id { get; set; }

    public string? Email { get; set; }
    public string? PasswordHash { get; set; }

    public string? FullName { get; set; }

    public string? Role { get; set; }  // "Candidate" or "Recruiter"

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }

    // =========================
    // NAVIGATION PROPERTIES
    // =========================

    // One-to-One
    public CandidateProfile? CandidateProfile { get; set; }
    public RecruiterProfile? RecruiterProfile { get; set; }

    // One-to-Many
    public List<RefreshToken> RefreshTokens { get; set; } = new();
}