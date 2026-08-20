using CareerConnect.Application.Features.Applications.DTOs;
using CareerConnect.Application.Features.Applications.Interfaces;
using CareerConnect.Application.Features.Candidates.Interfaces;
using CareerConnect.Application.Features.Resumes.Interfaces;
using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Applications.Services;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IResumeRepository _resumeRepository;
    private readonly ICandidateRepository _candidateRepository;

    public ApplicationService(
        IApplicationRepository applicationRepository,
        IResumeRepository resumeRepository,
        ICandidateRepository candidateRepository)
    {
        _applicationRepository = applicationRepository;
        _resumeRepository = resumeRepository;
        _candidateRepository = candidateRepository;
    }

    public async Task ApplyAsync(CreateApplicationDto request, int userId)
    {
        var candidate = await _candidateRepository.GetByUserIdAsync(userId);

        if (candidate == null)
            throw new Exception("Candidate profile not found");

        var resumes = await _resumeRepository.GetByCandidateIdAsync(candidate.Id);

        var resume = resumes.FirstOrDefault(r => r.IsCurrent);

        if (resume == null)
            throw new Exception("Please upload resume before applying");

        var application = new JobApplication
        {
            JobPostingId = request.JobId,
            CandidateId = candidate.Id,   // ✅ FIX HERE
            ResumeId = resume.Id,
            AppliedAt = DateTime.UtcNow,
            Status = "Applied"
        };

        await _applicationRepository.AddAsync(application);
    }

    public async Task<List<ApplicationResponseDto>> GetMyApplicationsAsync(int userId)
    {
        var candidate = await _candidateRepository.GetByUserIdAsync(userId);

        if (candidate == null)
            throw new Exception("Candidate profile not found");

        var applications = await _applicationRepository
            .GetByCandidateIdAsync(candidate.Id);

        return applications.Select(a => new ApplicationResponseDto
        {
            Id = a.Id,
            JobId = a.JobPostingId,
            CandidateId = a.CandidateId,   // 🔥 FIX
            Status = a.Status,
            AppliedAt = a.AppliedAt       // 🔥 FIX
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