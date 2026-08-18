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

    public async Task<List<ApplicationResponseDto>> GetApplicationsByJobAsync(int jobId)
    {
        var applications = await _applicationRepository.GetByJobIdAsync(jobId);

        return applications.Select(a => new ApplicationResponseDto
        {
            Id = a.Id,
            JobId = a.JobPostingId,
            JobTitle = a.JobPosting?.Title,
            CompanyName = a.JobPosting?.Recruiter?.CompanyName,
            AppliedAt = a.AppliedAt,
            Status = a.Status
        }).ToList();
    }

    public async Task UpdateStatusAsync(int id, int status)
    {
        var application = await _applicationRepository.GetByIdAsync(id);

        if (application == null)
            throw new Exception("Application not found");

        application.Status = status;

        await _applicationRepository.UpdateAsync(application);
    }

    public async Task DeleteAsync(int id)
    {
        var application = await _applicationRepository.GetByIdAsync(id);

        if (application == null)
            throw new Exception("Application not found");

        await _applicationRepository.DeleteAsync(application);
    }



}