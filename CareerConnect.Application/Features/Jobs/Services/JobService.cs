using CareerConnect.Application.Features.Jobs.DTOs;
using CareerConnect.Application.Features.Jobs.Interfaces;
using CareerConnect.Domain.Entities;
using CareerConnect.Shared.Exceptions;
using System.Security.Claims;
public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task CreateJobAsync(Job job)
    {
        // 🔥 Business rule: recruiterId must exist
        if (job.RecruiterId <= 0)
            throw new Exception("Invalid recruiter");

        await _jobRepository.AddAsync(job);
    }

    public async Task<List<Job>> GetAllJobsAsync()
    {
        return await _jobRepository.GetAllAsync();
    }

    public async Task<Job?> GetJobByIdAsync(int id)
    {
        return await _jobRepository.GetByIdAsync(id);
    }

    public async Task<List<Job>> GetJobsByRecruiterAsync(int recruiterId)
    {
        return await _jobRepository.GetByRecruiterIdAsync(recruiterId);
    }

    public async Task UpdateJobAsync(Job job)
    {
        var existingJob = await _jobRepository.GetByIdAsync(job.Id);

        if (existingJob == null)
            throw new Exception("Job not found");

        // 🔥 SECURITY: only owner can update
        if (existingJob.RecruiterId != job.RecruiterId)
            throw new Exception("Unauthorized");

        await _jobRepository.UpdateAsync(job);
    }

    public async Task DeleteJobAsync(int id, int recruiterId)
    {
        var job = await _jobRepository.GetByIdAsync(id);

        if (job == null)
            throw new Exception("Job not found");

        // 🔥 SECURITY: only owner can delete
        if (job.RecruiterId != recruiterId)
            throw new Exception("Unauthorized");

        await _jobRepository.DeleteAsync(job);
    }


    public async Task AddAsync(CreateJobRequest request, ClaimsPrincipal user)
    {
        var role = user.FindFirst(ClaimTypes.Role)?.Value;
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (role != "Recruiter")
        {
            throw new UnauthorizedException("Only recruiters can create jobs");
        }

        var job = new Job
        {
            Title = request.Title,
            Description = request.Description,
            Location = request.Location,
            Salary = request.Salary,
            RecruiterId = int.Parse(userId!),
            CreatedBy = int.Parse(userId!),
            CreatedAt = DateTime.UtcNow
        };

        await _jobRepository.AddAsync(job);
    }
}