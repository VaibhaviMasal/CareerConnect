using CareerConnect.Application.Features.Jobs.DTOs;
using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Jobs.Interfaces;

public interface IJobService
{
    Task CreateJobAsync(CreateJobRequestDto request, int recruiterId);

    Task<List<JobPosting>> GetAllJobsAsync();

    Task<JobPosting?> GetJobByIdAsync(int id);

    Task<List<JobPosting>> GetJobsByRecruiterAsync(int recruiterId);

    Task UpdateJobAsync(int id, CreateJobRequestDto request);

    Task<bool> DeleteJobAsync(int id);
}