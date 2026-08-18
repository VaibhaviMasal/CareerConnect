using CareerConnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareerConnect.Infrastructure.Persistence;

public partial class CareerConnectDbContext : DbContext
{
    public CareerConnectDbContext(DbContextOptions<CareerConnectDbContext> options)
        : base(options)
    {
    }

    // 🔥 IMPORTANT: keep naming consistent
    public DbSet<JobApplication> JobApplications { get; set; }

    public DbSet<CandidateProfile> CandidateProfiles { get; set; }
    public DbSet<InterviewSchedule> InterviewSchedules { get; set; }
    public DbSet<JobPosting> JobPostings { get; set; }
    public DbSet<RecruiterProfile> RecruiterProfiles { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Resume> Resumes { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<User> Users { get; set; }

    // ❌ REMOVE this if not needed (confusing duplicate)
    // public DbSet<Job> Jobs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // =========================
        // JOB APPLICATION
        // =========================
        modelBuilder.Entity<JobApplication>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.AppliedAt)
                  .HasDefaultValueSql("GETDATE()");

            entity.HasOne(e => e.Candidate)
                  .WithMany(c => c.Applications)
                  .HasForeignKey(e => e.CandidateId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.JobPosting)
                  .WithMany(j => j.Applications)
                  .HasForeignKey(e => e.JobPostingId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Resume)
                  .WithMany(r => r.Applications)
                  .HasForeignKey(e => e.ResumeId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // =========================
        // CANDIDATE PROFILE
        // =========================
        modelBuilder.Entity<CandidateProfile>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.User)
                  .WithOne(u => u.CandidateProfile)
                  .HasForeignKey<CandidateProfile>(e => e.UserId);

            entity.HasMany(e => e.Skills)
                  .WithMany(s => s.CandidateProfiles)
                  .UsingEntity(j => j.ToTable("CandidateSkills"));
        });

        // =========================
        // INTERVIEW SCHEDULE
        // =========================
        modelBuilder.Entity<InterviewSchedule>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CreatedAt)
                  .HasDefaultValueSql("GETDATE()");

            entity.HasOne(e => e.Application)
                  .WithMany(a => a.InterviewSchedules)
                  .HasForeignKey(e => e.ApplicationId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // =========================
        // JOB POSTING
        // =========================
        modelBuilder.Entity<JobPosting>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(j => j.CreatedAt)
                  .HasDefaultValueSql("GETUTCDATE()");

            entity.Property(e => e.IsActive)
                  .HasDefaultValue(true);

            entity.HasOne(e => e.Recruiter)
                  .WithMany(r => r.JobPostings)
                  .HasForeignKey(e => e.RecruiterId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.Skills)
                  .WithMany(s => s.JobPostings)
                  .UsingEntity(j => j.ToTable("JobPostingSkills"));
        });

        // =========================
        // RECRUITER PROFILE
        // =========================
        modelBuilder.Entity<RecruiterProfile>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.User)
                  .WithOne(u => u.RecruiterProfile)
                  .HasForeignKey<RecruiterProfile>(e => e.UserId);
        });

        // =========================
        // REFRESH TOKEN
        // =========================
        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CreatedAt)
                  .HasDefaultValueSql("GETDATE()");

            entity.HasOne(e => e.User)
                  .WithMany(u => u.RefreshTokens)
                  .HasForeignKey(e => e.UserId);
        });

        // =========================
        // RESUME
        // =========================
        modelBuilder.Entity<Resume>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.IsCurrent)
                  .HasDefaultValue(true);

            entity.Property(e => e.UploadedAt)
                  .HasDefaultValueSql("GETDATE()");

            entity.HasOne(e => e.Candidate)
                  .WithMany(c => c.Resumes)
                  .HasForeignKey(e => e.CandidateId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // =========================
        // SKILL
        // =========================
        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // =========================
        // USER
        // =========================
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CreatedAt)
                  .HasDefaultValueSql("GETDATE()");

            entity.Property(e => e.IsActive)
                  .HasDefaultValue(true);
        });
    }
}