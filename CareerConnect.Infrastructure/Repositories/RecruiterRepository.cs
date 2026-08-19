
using CareerConnect.Application.Features.Recruiters.Interfaces;
using CareerConnect.Domain.Entities;
using CareerConnect.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CareerConnect.Infrastructure.Repositories;

public class RecruiterRepository : IRecruiterRepository
{
    private readonly CareerConnectDbContext _context;

    public RecruiterRepository(CareerConnectDbContext context)
    {
        _context = context;
    }

    public async Task<RecruiterProfile?> GetByUserIdAsync(int userId)
    {
        return await _context.RecruiterProfiles
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task AddAsync(RecruiterProfile profile)
    {
        await _context.RecruiterProfiles.AddAsync(profile);
        await _context.SaveChangesAsync();
    }
}