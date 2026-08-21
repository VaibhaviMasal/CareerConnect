using CareerConnect.Domain.Entities;
using CareerConnect.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CareerConnect.Infrastructure.Seed;

public static class DbSeeder
{
    public static async Task SeedAsync(CareerConnectDbContext context)
    {
        // Make sure database is available
        await context.Database.MigrateAsync();

        // =====================================================
        // 1. SEED SKILLS
        // =====================================================

        var skillNames = new[]
        {
            "C#",
            ".NET",
            "ASP.NET Core",
            "Java",
            "JavaScript",
            "React",
            "SQL",
            "Python",
            "Git",
            "Azure"
        };

        var existingSkills = await context.Skills
            .Where(s => skillNames.Contains(s.Name))
            .ToListAsync();

        var existingSkillNames = existingSkills
            .Select(s => s.Name)
            .ToHashSet();

        var newSkills = skillNames
            .Where(name => !existingSkillNames.Contains(name))
            .Select(name => new Skill
            {
                Name = name
            })
            .ToList();

        if (newSkills.Count > 0)
        {
            await context.Skills.AddRangeAsync(newSkills);
            await context.SaveChangesAsync();
        }


        // =====================================================
        // 2. SEED DEMO RECRUITER USER
        // =====================================================

        const string recruiterEmail = "recruiter.demo@careerconnect.com";

        var recruiterUser = await context.Users
            .FirstOrDefaultAsync(u => u.Email == recruiterEmail);

        if (recruiterUser == null)
        {
            recruiterUser = new User
            {
                FullName = "Demo Recruiter",
                Email = recruiterEmail,

                // Password: Recruiter@123
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Recruiter@123"),

                Role = "Recruiter",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await context.Users.AddAsync(recruiterUser);
            await context.SaveChangesAsync();
        }


        // =====================================================
        // 3. SEED RECRUITER PROFILE
        // =====================================================

        var recruiterProfile = await context.RecruiterProfiles
            .FirstOrDefaultAsync(r => r.UserId == recruiterUser.Id);

        if (recruiterProfile == null)
        {
            recruiterProfile = new RecruiterProfile
            {
                UserId = recruiterUser.Id,
                CompanyName = "TechNova Solutions",
                Position = "Senior Recruiter",
                City = "Pune"
            };

            await context.RecruiterProfiles.AddAsync(recruiterProfile);
            await context.SaveChangesAsync();
        }


        // =====================================================
        // 4. SEED DEMO CANDIDATE USER
        // =====================================================

        const string candidateEmail = "candidate.demo@careerconnect.com";

        var candidateUser = await context.Users
            .FirstOrDefaultAsync(u => u.Email == candidateEmail);

        if (candidateUser == null)
        {
            candidateUser = new User
            {
                FullName = "Demo Candidate",
                Email = candidateEmail,

                // Password: Candidate@123
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Candidate@123"),

                Role = "Candidate",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await context.Users.AddAsync(candidateUser);
            await context.SaveChangesAsync();
        }


        // =====================================================
        // 5. SEED CANDIDATE PROFILE
        // =====================================================

        var candidateProfile = await context.CandidateProfiles
            .FirstOrDefaultAsync(c => c.UserId == candidateUser.Id);

        if (candidateProfile == null)
        {
            candidateProfile = new CandidateProfile
            {
                UserId = candidateUser.Id,
                Skills = "C#, .NET, SQL",
                Experience = "Fresher",
                Education = "B.E. Information Technology",
                City = "Pune"
            };

            await context.CandidateProfiles.AddAsync(candidateProfile);
            await context.SaveChangesAsync();
        }


        // =====================================================
        // 6. GET SKILLS FOR JOBS
        // =====================================================

        var csharp = await context.Skills
            .FirstAsync(s => s.Name == "C#");

        var dotnet = await context.Skills
            .FirstAsync(s => s.Name == ".NET");

        var aspnet = await context.Skills
            .FirstAsync(s => s.Name == "ASP.NET Core");

        var java = await context.Skills
            .FirstAsync(s => s.Name == "Java");

        var javascript = await context.Skills
            .FirstAsync(s => s.Name == "JavaScript");

        var react = await context.Skills
            .FirstAsync(s => s.Name == "React");

        var sql = await context.Skills
            .FirstAsync(s => s.Name == "SQL");


        // =====================================================
        // 7. SEED JOB POSTINGS
        // =====================================================

        var existingJobs = await context.JobPostings
            .Where(j => j.RecruiterId == recruiterProfile.Id)
            .ToListAsync();


        // -----------------------------------------------------
        // JOB 1 - .NET DEVELOPER
        // -----------------------------------------------------

        if (!existingJobs.Any(j => j.Title == ".NET Developer"))
        {
            var job = new JobPosting
            {
                RecruiterId = recruiterProfile.Id,
                Title = ".NET Developer",
                Description = "Looking for a .NET developer to build and maintain scalable web applications.",
                Location = "Pune",
                MinExperience = 0,
                MaxExperience = 3,
                Deadline = DateTime.UtcNow.AddDays(30),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true
            };

            job.Skills.Add(csharp);
            job.Skills.Add(dotnet);
            job.Skills.Add(aspnet);
            job.Skills.Add(sql);

            await context.JobPostings.AddAsync(job);
        }


        // -----------------------------------------------------
        // JOB 2 - JAVA DEVELOPER
        // -----------------------------------------------------

        if (!existingJobs.Any(j => j.Title == "Java Developer"))
        {
            var job = new JobPosting
            {
                RecruiterId = recruiterProfile.Id,
                Title = "Java Developer",
                Description = "Looking for a Java developer to develop backend services and enterprise applications.",
                Location = "Mumbai",
                MinExperience = 0,
                MaxExperience = 3,
                Deadline = DateTime.UtcNow.AddDays(30),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true
            };

            job.Skills.Add(java);
            job.Skills.Add(sql);

            await context.JobPostings.AddAsync(job);
        }


        // -----------------------------------------------------
        // JOB 3 - FRONTEND DEVELOPER
        // -----------------------------------------------------

        if (!existingJobs.Any(j => j.Title == "Frontend Developer"))
        {
            var job = new JobPosting
            {
                RecruiterId = recruiterProfile.Id,
                Title = "Frontend Developer",
                Description = "Looking for a frontend developer to build responsive and user-friendly web applications.",
                Location = "Bangalore",
                MinExperience = 0,
                MaxExperience = 2,
                Deadline = DateTime.UtcNow.AddDays(30),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true
            };

            job.Skills.Add(javascript);
            job.Skills.Add(react);

            await context.JobPostings.AddAsync(job);
        }


        // =====================================================
        // SAVE ALL NEW JOBS
        // =====================================================

        await context.SaveChangesAsync();
    }
}