using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Jobs.Interfaces;

public interface IJobService
{
    Task CreateJobAsync(JobPosting job);
    Task<List<JobPosting>> GetAllJobsAsync();
    Task<JobPosting?> GetJobByIdAsync(int id);
}