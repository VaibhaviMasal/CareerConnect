using CareerConnect.Application.Features.Jobs.DTOs;
using CareerConnect.Domain.Entities;
using System.Security.Claims;

namespace CareerConnect.Application.Features.Jobs.Interfaces;

public interface IJobService
{
    Task CreateJobAsync(Job job);
    Task<List<Job>> GetAllJobsAsync();
    Task<Job?> GetJobByIdAsync(int id);
    Task<List<Job>> GetJobsByRecruiterAsync(int recruiterId);
    Task UpdateJobAsync(Job job);
    Task DeleteJobAsync(int id, int recruiterId);

    Task AddAsync(CreateJobRequest request, ClaimsPrincipal user);
}