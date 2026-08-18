using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Applications.Interfaces;

public interface IApplicationRepository
{
    Task AddAsync(JobApplication application);

    Task<List<JobApplication>> GetByCandidateIdAsync(int candidateId);


}