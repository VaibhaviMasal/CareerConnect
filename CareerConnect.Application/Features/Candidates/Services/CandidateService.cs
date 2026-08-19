using CareerConnect.Application.Features.Candidates.DTOs;
using CareerConnect.Application.Features.Candidates.Interfaces;


using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Candidates.Services;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _repository;

    public CandidateService(ICandidateRepository repository)
    {
        _repository = repository;
    }

    // CREATE PROFILE
    public async Task CreateAsync(CreateCandidateDto dto, int userId)
    {
        var existing = await _repository.GetByUserIdAsync(userId);

        if (existing != null)
            throw new Exception("Profile already exists");

        var profile = new CandidateProfile
        {
            UserId = userId,
            Skills = dto.Skills,
            Experience = dto.Experience,
            Education = dto.Education,
            City = dto.City
        };

        await _repository.AddAsync(profile);
    }

    // GET MY PROFILE
    public async Task<CandidateResponseDto> GetMyProfileAsync(int userId)
    {
        var profile = await _repository.GetByUserIdAsync(userId);

        if (profile == null)
            throw new Exception("Profile not found");

        return new CandidateResponseDto
        {
            Id = profile.Id,
            UserId = profile.UserId,
            Skills = profile.Skills,
            Experience = profile.Experience,
            Education = profile.Education,
            City = profile.City
        };
    }
}