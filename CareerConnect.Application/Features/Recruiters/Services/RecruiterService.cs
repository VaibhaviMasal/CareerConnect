using CareerConnect.Application.Features.Recruiters.DTOs;
using CareerConnect.Application.Features.Recruiters.Interfaces;
using CareerConnect.Domain.Entities;

public class RecruiterService : IRecruiterService
{
    private readonly IRecruiterRepository _repository;

    public RecruiterService(IRecruiterRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(CreateRecruiterDto request, int userId)
    {
        var recruiter = new RecruiterProfile
        {
            UserId = userId,
            CompanyName = request.CompanyName,
            Position = request.Position,
            City = request.City
        };

        await _repository.AddAsync(recruiter);
    }

    public async Task<RecruiterResponseDto> GetByIdAsync(int id)
    {
        var recruiter = await _repository.GetByIdAsync(id);

        if (recruiter == null)
            throw new Exception("Recruiter not found");

        return new RecruiterResponseDto
        {
            Id = recruiter.Id,
            UserId = recruiter.UserId,
            CompanyName = recruiter.CompanyName,
            Position = recruiter.Position,
            City = recruiter.City
        };
    }

    public async Task UpdateAsync(int userId, UpdateRecruiterDto request)
    {
        var recruiter = await _repository.GetByUserIdAsync(userId);

        if (recruiter == null)
            throw new Exception("Recruiter profile not found");

        recruiter.CompanyName = request.CompanyName;
        recruiter.Position = request.Position;
        recruiter.City = request.City;

        await _repository.UpdateAsync(recruiter);
    }

    public async Task DeleteAsync(int userId)
    {
        var recruiter = await _repository.GetByUserIdAsync(userId);

        if (recruiter == null)
            throw new Exception("Recruiter profile not found");

        await _repository.DeleteAsync(recruiter);
    }

    public async Task<RecruiterResponseDto> GetByUserIdAsync(int userId)
    {
        var recruiter = await _repository.GetByUserIdAsync(userId);

        if (recruiter == null)
            throw new Exception("Recruiter not found");

        return new RecruiterResponseDto
        {
            Id = recruiter.Id,
            CompanyName = recruiter.CompanyName,
            Position = recruiter.Position,
            City = recruiter.City
        };
    }
}