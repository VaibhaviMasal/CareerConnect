using CareerConnect.Application.Features.Candidates.Interfaces;
using CareerConnect.Application.Features.Resumes.DTOs;
using CareerConnect.Application.Features.Resumes.Interfaces;
using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Resumes.Services;

public class ResumeService : IResumeService
{
    private readonly IResumeRepository _repository;
    private readonly ICandidateRepository _candidateRepository;

    public ResumeService(
        IResumeRepository repository,
        ICandidateRepository candidateRepository)
    {
        _repository = repository;
        _candidateRepository = candidateRepository;
    }

    // ✅ UPLOAD RESUME
    public async Task UploadAsync(UploadResumeDto request, int userId)
    {
        // 🔍 Get candidate
        var candidate = await _candidateRepository.GetByUserIdAsync(userId);

        if (candidate == null)
            throw new Exception("Candidate profile not found");

        // 📁 Prepare folder path
        var folderPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "wwwroot",
            "resumes"
        );

        // ✅ Ensure folder exists
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // 🏷️ Generate unique filename
        var fileName = Guid.NewGuid() + Path.GetExtension(request.File.FileName);

        // 📍 Full physical path
        var filePath = Path.Combine(folderPath, fileName);

        // 💾 Save file
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await request.File.CopyToAsync(stream);
        }

        // 🌐 URL for DB
        var fileUrl = "/resumes/" + fileName;

        // 🔁 Mark old resumes as not current
        var resumes = await _repository.GetByCandidateIdAsync(candidate.Id);

        foreach (var r in resumes)
        {
            r.IsCurrent = false;
        }

        // 🆕 Save new resume
        var resume = new Resume
        {
            CandidateId = candidate.Id,
            FileUrl = fileUrl,
            IsCurrent = true,
            UploadedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(resume);
    }

    // ✅ GET MY RESUMES
    public async Task<List<ResumeResponseDto>> GetMyResumesAsync(int userId)
    {
        var candidate = await _candidateRepository.GetByUserIdAsync(userId);

        if (candidate == null)
            throw new Exception("Candidate not found");

        var resumes = await _repository.GetByCandidateIdAsync(candidate.Id);

        return resumes.Select(r => new ResumeResponseDto
        {
            Id = r.Id,
            FileUrl = r.FileUrl,
            IsCurrent = r.IsCurrent
        }).ToList();
    }

    // ✅ UPDATE RESUME
    public async Task UpdateAsync(UpdateResumeDto request, int userId)
    {
        var candidate = await _candidateRepository.GetByUserIdAsync(userId);

        if (candidate == null)
            throw new Exception("Candidate not found");

        var resume = await _repository.GetByIdAsync(request.Id);

        if (resume == null || resume.CandidateId != candidate.Id)
            throw new Exception("Resume not found");

        resume.FileUrl = request.FileUrl;
        resume.IsCurrent = request.IsCurrent;

        await _repository.UpdateAsync(resume);
    }

    // ✅ DELETE RESUME
    public async Task DeleteAsync(int resumeId, int userId)
    {
        var candidate = await _candidateRepository.GetByUserIdAsync(userId);

        if (candidate == null)
            throw new Exception("Candidate not found");

        var resume = await _repository.GetByIdAsync(resumeId);

        if (resume == null || resume.CandidateId != candidate.Id)
            throw new Exception("Resume not found");

        await _repository.DeleteAsync(resume);
    }
}