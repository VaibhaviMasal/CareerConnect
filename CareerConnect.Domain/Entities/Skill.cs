using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CareerConnect.Domain.Entities;


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
