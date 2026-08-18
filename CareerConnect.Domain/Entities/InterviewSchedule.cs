using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CareerConnect.Domain.Entities;

public partial class InterviewSchedule
{
    [Key]
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InterviewDate { get; set; }

    public int? Mode { get; set; }

    [StringLength(300)]
    public string? LocationOrLink { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("ApplicationId")]
    [InverseProperty("InterviewSchedules")]
    public virtual JobApplication Application { get; set; } = null!;
}
