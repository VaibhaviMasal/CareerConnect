using System;
using System.Collections.Generic;
using CareerConnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareerConnect.Infrastructure.Persistence;

public partial class CareerConnectDbContext : DbContext
{
    public CareerConnectDbContext(DbContextOptions<CareerConnectDbContext> options)
        : base(options)
    {
    }

    public DbSet<CareerConnect.Domain.Entities.Application> Applications { get; set; }

    public virtual DbSet<CandidateProfile> CandidateProfiles { get; set; }

    public virtual DbSet<InterviewSchedule> InterviewSchedules { get; set; }

    public virtual DbSet<JobPosting> JobPostings { get; set; }

    public virtual DbSet<RecruiterProfile> RecruiterProfiles { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Resume> Resumes { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public DbSet<Job> Jobs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CareerConnect.Domain.Entities.Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC07DCE370C2");

            entity.Property(e => e.AppliedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Candidate).WithMany(p => p.Applications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicati__Candi__6D0D32F4");

            entity.HasOne(d => d.JobPosting).WithMany(p => p.Applications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicati__JobPo__6E01572D");

            entity.HasOne(d => d.Resume).WithMany(p => p.Applications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicati__Resum__6EF57B66");
        });

        modelBuilder.Entity<CandidateProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Candidat__3214EC07EDFA4F08");

            entity.HasOne(d => d.User).WithOne(p => p.CandidateProfile).HasConstraintName("FK__Candidate__UserI__5070F446");

            entity.HasMany(d => d.Skills).WithMany(p => p.CandidateProfiles)
                .UsingEntity<Dictionary<string, object>>(
                    "CandidateSkill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .HasConstraintName("FK__Candidate__Skill__5AEE82B9"),
                    l => l.HasOne<CandidateProfile>().WithMany()
                        .HasForeignKey("CandidateProfileId")
                        .HasConstraintName("FK__Candidate__Candi__59FA5E80"),
                    j =>
                    {
                        j.HasKey("CandidateProfileId", "SkillId").HasName("PK__Candidat__C0E72DC8CDDF0F58");
                        j.ToTable("CandidateSkills");
                    });
        });

        modelBuilder.Entity<InterviewSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Intervie__3214EC07826CAFB6");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Application).WithMany(p => p.InterviewSchedules).HasConstraintName("FK__Interview__Appli__72C60C4A");
        });

        modelBuilder.Entity<JobPosting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobPosti__3214EC0728DF0328");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Recruiter).WithMany(p => p.JobPostings).HasConstraintName("FK__JobPostin__Recru__5FB337D6");

            entity.HasMany(d => d.Skills).WithMany(p => p.JobPostings)
                .UsingEntity<Dictionary<string, object>>(
                    "JobPostingSkill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .HasConstraintName("FK__JobPostin__Skill__6383C8BA"),
                    l => l.HasOne<JobPosting>().WithMany()
                        .HasForeignKey("JobPostingId")
                        .HasConstraintName("FK__JobPostin__JobPo__628FA481"),
                    j =>
                    {
                        j.HasKey("JobPostingId", "SkillId").HasName("PK__JobPosti__58F0A2D16D591C01");
                        j.ToTable("JobPostingSkills");
                    });
        });

        modelBuilder.Entity<RecruiterProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recruite__3214EC07C8E8C124");

            entity.HasOne(d => d.User).WithOne(p => p.RecruiterProfile).HasConstraintName("FK__Recruiter__UserI__5441852A");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RefreshT__3214EC0793B029E2");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens).HasConstraintName("FK_RefreshTokens_Users");
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resumes__3214EC076E9115AB");

            entity.Property(e => e.IsCurrent).HasDefaultValue(true);
            entity.Property(e => e.UploadedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Candidate).WithMany(p => p.Resumes).HasConstraintName("FK__Resumes__Candida__68487DD7");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC070CF1D3D0");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC079E029BCB");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<Job>(entity =>
        {
            entity.Property(e => e.Salary)
                  .HasPrecision(18, 2); // ✅ 18 total digits, 2 after decimal
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
