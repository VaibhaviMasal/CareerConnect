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

    public async Task ApplyAsync(CreateApplicationDto request, int userId)
    {
        var application = new JobApplication
        {
            JobPostingId = request.JobId,
            CandidateId = userId,
            AppliedAt = DateTime.UtcNow,
            Status = "Applied"
        };

        await _applicationRepository.AddAsync(application);
    }

    public async Task<List<ApplicationResponseDto>> GetMyApplicationsAsync(int userId)
    {
        var applications = await _applicationRepository.GetByCandidateIdAsync(userId);

        return applications.Select(a => new ApplicationResponseDto
        {
            Id = a.Id,
            JobId = a.JobPostingId,   // int → int ✅
            Status = a.Status         // string → string ✅
        }).ToList();
    }

    public async Task<List<ApplicationResponseDto>> GetByJobIdAsync(int jobId)
    {
        var applications = await _applicationRepository.GetByJobIdAsync(jobId);

        return applications.Select(a => new ApplicationResponseDto
        {
            Id = a.Id,
            JobId = a.JobPostingId,
            Status = a.Status
        }).ToList();
    }

    public async Task UpdateStatusAsync(int id, string status)
    {
        var app = await _applicationRepository.GetByIdAsync(id);

        if (app == null)
            throw new Exception("Application not found");

        app.Status = status;

        await _applicationRepository.UpdateAsync(app);
    }

    public async Task DeleteAsync(int id)
    {
        var app = await _applicationRepository.GetByIdAsync(id);

        if (app == null)
            throw new Exception("Application not found");

        await _applicationRepository.DeleteAsync(app);
    }
}