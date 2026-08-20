using CareerConnect.Application.Features.Candidates.Interfaces;
using CareerConnect.Domain.Entities;
using CareerConnect.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CareerConnect.Infrastructure.Repositories;

public class CandidateRepository : ICandidateRepository
{
    private readonly CareerConnectDbContext _context;

    public CandidateRepository(CareerConnectDbContext context)
    {
        _context = context;
    }

    // ✅ CREATE
    public async Task AddAsync(CandidateProfile candidate)
    {
        await _context.CandidateProfiles.AddAsync(candidate);
        await _context.SaveChangesAsync();
    }

    // ✅ GET BY USER ID (used in many places like Resume, Apply)
    public async Task<CandidateProfile?> GetByUserIdAsync(int userId)
    {
        return await _context.CandidateProfiles
            .FirstOrDefaultAsync(c => c.UserId == userId);
    }

    // ✅ GET BY ID (for search by id feature)
    public async Task<CandidateProfile?> GetByIdAsync(int id)
    {
        return await _context.CandidateProfiles
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    // ✅ GET ALL (optional but useful)
    public async Task<List<CandidateProfile>> GetAllAsync()
    {
        return await _context.CandidateProfiles.ToListAsync();
    }

    // ✅ UPDATE
    public async Task UpdateAsync(CandidateProfile candidate)
    {
        _context.CandidateProfiles.Update(candidate);
        await _context.SaveChangesAsync();
    }

    // ✅ DELETE
    public async Task DeleteAsync(CandidateProfile candidate)
    {
        _context.CandidateProfiles.Remove(candidate);
        await _context.SaveChangesAsync();
    }
}