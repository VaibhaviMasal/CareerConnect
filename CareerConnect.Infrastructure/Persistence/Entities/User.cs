using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CareerConnect.Infrastructure.Persistence.Entities;

[Index("Email", Name = "UQ__Users__A9D10534111A613E", IsUnique = true)]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    public int Role { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("User")]
    public virtual CandidateProfile? CandidateProfile { get; set; }

    [InverseProperty("User")]
    public virtual RecruiterProfile? RecruiterProfile { get; set; }
}
