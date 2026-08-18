using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Jobs.Interfaces;

public interface IJobRepository
{
    Task AddAsync(JobPosting job);
    Task<List<JobPosting>> GetAllAsync();
    Task<JobPosting?> GetByIdAsync(int id);
    Task<List<JobPosting>> GetByRecruiterIdAsync(int recruiterId);
    Task UpdateAsync(JobPosting job);
    Task DeleteAsync(JobPosting job);

    Task<int?> GetRecruiterProfileIdByUserIdAsync(int userId);
}