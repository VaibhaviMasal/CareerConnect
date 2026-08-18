using CareerConnect.Application.Features.Jobs.DTOs;
using CareerConnect.Application.Features.Jobs.Interfaces;
using CareerConnect.Domain.Entities;


namespace CareerConnect.Application.Features.Jobs.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    // ✅ CREATE JOB
    public async Task CreateJobAsync(CreateJobRequestDto request, int userId)
    {
        var recruiterId = await _jobRepository
            .GetRecruiterProfileIdByUserIdAsync(userId);

        if (recruiterId == null)
            throw new Exception("Recruiter profile not found");

        var job = new JobPosting
        {
            Title = request.Title,
            Description = request.Description,
            Location = request.Location,
            MinExperience = request.MinExperience,
            MaxExperience = request.MaxExperience,

            RecruiterId = recruiterId.Value,

            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };

        await _jobRepository.AddAsync(job);
    }

    // ✅ GET ALL JOBS
    public async Task<List<JobPosting>> GetAllJobsAsync()
    {
        return await _jobRepository.GetAllAsync();
    }

    // ✅ GET BY ID
    public async Task<JobPosting?> GetJobByIdAsync(int id)
    {
        return await _jobRepository.GetByIdAsync(id);
    }

    // ✅ GET BY RECRUITER
    public async Task<List<JobPosting>> GetJobsByRecruiterAsync(int recruiterId)
    {
        return await _jobRepository.GetByRecruiterIdAsync(recruiterId);
    }

    // ✅ UPDATE JOB
    public async Task UpdateJobAsync(int id, CreateJobRequestDto request)
    {
        var job = await _jobRepository.GetByIdAsync(id);

        if (job == null)
            throw new Exception("Job not found");

        job.Title = request.Title;
        job.Description = request.Description;
        job.Location = request.Location;
        job.MinExperience = request.MinExperience;
        job.MaxExperience = request.MaxExperience;

        job.UpdatedAt = DateTime.UtcNow; // ⚠️ FIX

        await _jobRepository.UpdateAsync(job);
    }

    // ✅ DELETE JOB
    public async Task<bool> DeleteJobAsync(int id)
    {
        var job = await _jobRepository.GetByIdAsync(id);

        if (job == null)
            return false;

        await _jobRepository.DeleteAsync(job);
        return true;
    }
}