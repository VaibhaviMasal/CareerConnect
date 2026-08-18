using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Applications.Interfaces;

public interface IApplicationRepository
{
    Task AddAsync(JobApplication application);

    Task<List<JobApplication>> GetByCandidateIdAsync(int candidateId);

    Task<List<JobApplication>> GetByJobIdAsync(int jobId);
    Task<JobApplication?> GetByIdAsync(int id);
    Task UpdateAsync(JobApplication application);
    Task DeleteAsync(JobApplication application);
}