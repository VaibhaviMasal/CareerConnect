using CareerConnect.Application.Features.Recruiters.Interfaces;
using CareerConnect.Domain.Entities;
using CareerConnect.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class RecruiterRepository : IRecruiterRepository
{
    private readonly CareerConnectDbContext _context;

    public RecruiterRepository(CareerConnectDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(RecruiterProfile recruiter)
    {
        await _context.RecruiterProfiles.AddAsync(recruiter);
        await _context.SaveChangesAsync();
    }

    public async Task<RecruiterProfile?> GetByUserIdAsync(int userId)
    {
        return await _context.RecruiterProfiles
            .FirstOrDefaultAsync(r => r.UserId == userId);
    }

    public async Task<RecruiterProfile?> GetByIdAsync(int id)
    {
        return await _context.RecruiterProfiles.FindAsync(id);
    }

    public async Task UpdateAsync(RecruiterProfile recruiter)
    {
        _context.RecruiterProfiles.Update(recruiter);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(RecruiterProfile recruiter)
    {
        _context.RecruiterProfiles.Remove(recruiter);
        await _context.SaveChangesAsync();
    }
}