
using CareerConnect.Application.Features.Recruiters.DTOs;
using CareerConnect.Application.Features.Recruiters.Interfaces;
using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Recruiter.Services;

public class RecruiterService : IRecruiterService
{
    private readonly IRecruiterRepository _repository;

    public RecruiterService(IRecruiterRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(CreateRecruiterDto dto, int userId)
    {
        var existing = await _repository.GetByUserIdAsync(userId);

        if (existing != null)
            throw new Exception("Recruiter profile already exists");

        var profile = new RecruiterProfile
        {
            UserId = userId,
            CompanyName = dto.CompanyName,
            CompanyWebsite = dto.CompanyWebsite
        };

        await _repository.AddAsync(profile);
    }

    public async Task<RecruiterResponseDto> GetMyProfileAsync(int userId)
    {
        var profile = await _repository.GetByUserIdAsync(userId);

        if (profile == null)
            throw new Exception("Profile not found");

        return new RecruiterResponseDto
        {
            Id = profile.Id,
            UserId = profile.UserId,
            CompanyName = profile.CompanyName,
            CompanyWebsite = profile.CompanyWebsite
        };
    }
}