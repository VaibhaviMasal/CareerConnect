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
    public async Task CreateJobAsync(JobPosting job)
    {
        await _jobRepository.AddAsync(job);
    }

    // ✅ GET ALL JOBS
    public async Task<List<JobPosting>> GetAllJobsAsync()
    {
        return await _jobRepository.GetAllJobsAsync();
    }

    // ✅ GET JOB BY ID
    public async Task<JobPosting?> GetJobByIdAsync(int id)
    {
        return await _jobRepository.GetByIdAsync(id);
    }
}