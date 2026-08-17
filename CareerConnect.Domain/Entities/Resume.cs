using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CareerConnect.Domain.Entities;


public partial class Resume
{
    [Key]
    public int Id { get; set; }

    public int CandidateId { get; set; }

    [StringLength(200)]
    public string FileName { get; set; } = null!;

    [StringLength(500)]
    public string FilePath { get; set; } = null!;

    public int VersionNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UploadedAt { get; set; }

    public bool IsCurrent { get; set; }

    [InverseProperty("Resume")]
    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    [ForeignKey("CandidateId")]
    [InverseProperty("Resumes")]
    public virtual CandidateProfile Candidate { get; set; } = null!;
}
