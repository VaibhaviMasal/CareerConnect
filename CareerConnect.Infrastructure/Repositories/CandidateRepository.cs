using CareerConnect.Application.Features.Candidates.Interfaces;
using CareerConnect.Domain.Entities;

using CareerConnect.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class CandidateRepository : ICandidateRepository
{
    private readonly CareerConnectDbContext _context;

    public CandidateRepository(CareerConnectDbContext context)
    {
        _context = context;
    }

    public async Task<CandidateProfile?> GetByUserIdAsync(int userId)
    {
        return await _context.CandidateProfiles
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task AddAsync(CandidateProfile profile)
    {
        await _context.CandidateProfiles.AddAsync(profile);
        await _context.SaveChangesAsync();
    }
}