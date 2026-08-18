using CareerConnect.Domain.Entities;

public interface IJobRepository
{
    Task AddAsync(Job job);
    Task<List<Job>> GetAllAsync();
    Task<Job?> GetByIdAsync(int id);
    Task<List<Job>> GetByRecruiterIdAsync(int recruiterId);
    Task UpdateAsync(Job job);
    Task DeleteAsync(Job job);
}