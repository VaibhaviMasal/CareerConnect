using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CareerConnect.Infrastructure.Persistence.Entities;

[Index("Name", Name = "UQ__Skills__737584F62838DC36", IsUnique = true)]
public partial class Skill
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [ForeignKey("SkillId")]
    [InverseProperty("Skills")]
    public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; } = new List<CandidateProfile>();

    [ForeignKey("SkillId")]
    [InverseProperty("Skills")]
    public virtual ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
}
