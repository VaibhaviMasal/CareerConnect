using CareerConnect.Application.Features.Candidates.DTOs;
using CareerConnect.Application.Features.Candidates.Interfaces;
using CareerConnect.Domain.Entities;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _candidateRepository;

    public CandidateService(ICandidateRepository candidateRepository)
    {
        _candidateRepository = candidateRepository;
    }

    // ✅ CREATE
    public async Task CreateAsync(CreateCandidateDto request, int userId)
    {
        var existing = await _candidateRepository.GetByUserIdAsync(userId);

        if (existing != null)
            throw new Exception("Candidate profile already exists");

        var candidate = new CandidateProfile
        {
            UserId = userId,
            City = request.City,
            Education = request.Education,
            Experience = request.Experience,
            Skills = request.Skills
        };

        await _candidateRepository.AddAsync(candidate);
    }

    // ✅ UPDATE
    public async Task UpdateAsync(UpdateCandidateDto request, int userId)
    {
        var candidate = await _candidateRepository.GetByUserIdAsync(userId);

        if (candidate == null)
            throw new Exception("Candidate not found");

        candidate.City = request.City;
        candidate.Education = request.Education;
        candidate.Experience = request.Experience;
        candidate.Skills = request.Skills;

        await _candidateRepository.UpdateAsync(candidate);
    }

    // ✅ DELETE
    public async Task DeleteAsync(int userId)
    {
        var candidate = await _candidateRepository.GetByUserIdAsync(userId);

        if (candidate == null)
            throw new Exception("Candidate not found");

        await _candidateRepository.DeleteAsync(candidate);
    }

    // ✅ GET MY PROFILE
    public async Task<CandidateResponseDto> GetMyProfileAsync(int userId)
    {
        var candidate = await _candidateRepository.GetByUserIdAsync(userId);

        if (candidate == null)
            throw new Exception("Candidate not found");

        return new CandidateResponseDto
        {
            Id = candidate.Id,
            UserId = candidate.UserId,
            City = candidate.City,
            Education = candidate.Education,
            Experience = candidate.Experience,
            Skills = candidate.Skills
        };
    }

    // ✅ GET BY ID
    public async Task<CandidateResponseDto> GetByIdAsync(int id)
    {
        var candidate = await _candidateRepository.GetByIdAsync(id);

        if (candidate == null)
            throw new Exception("Candidate not found");

        return new CandidateResponseDto
        {
            Id = candidate.Id,
            UserId = candidate.UserId,
            City = candidate.City,
            Education = candidate.Education,
            Experience = candidate.Experience,
            Skills = candidate.Skills
        };
    }
}