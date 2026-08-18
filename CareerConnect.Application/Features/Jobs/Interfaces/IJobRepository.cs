using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Jobs.Interfaces;

public interface IJobRepository
{
    Task AddAsync(JobPosting job);
    Task<List<JobPosting>> GetAllJobsAsync();
    Task<JobPosting?> GetByIdAsync(int id);

    
}