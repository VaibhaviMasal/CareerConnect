using CareerConnect.Application.Features.Applications.DTOs;
using CareerConnect.Application.Features.Applications.Interfaces;
using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Applications.Services;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;

    public ApplicationService(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }

    public async Task ApplyAsync(ApplyJobRequestDto dto)
    {
        var application = new JobApplication
        {
            CandidateId = dto.CandidateId,
            JobPostingId = dto.JobId,
            ResumeId = dto.ResumeId,
            Status = 0,
            AppliedAt = DateTime.UtcNow
        };

        await _applicationRepository.AddAsync(application);
    }

    public async Task<List<ApplicationResponseDto>> GetMyApplicationsAsync(int candidateId)
    {
        var applications = await _applicationRepository.GetByCandidateIdAsync(candidateId);

        return applications.Select(a => new ApplicationResponseDto
        {
            Id = a.Id,
            JobId = a.JobPostingId,
            JobTitle = a.JobPosting.Title,
            CompanyName = a.JobPosting.Recruiter.CompanyName,
            AppliedAt = a.AppliedAt,
            Status = a.Status
        }).ToList();
    }



}