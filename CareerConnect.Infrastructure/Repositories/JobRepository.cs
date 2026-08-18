using CareerConnect.Application.Features.Jobs.Interfaces;
using CareerConnect.Domain.Entities;
using CareerConnect.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CareerConnect.Infrastructure.Repositories;

public class JobRepository : IJobRepository
{
    private readonly CareerConnectDbContext _context;

    public JobRepository(CareerConnectDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(JobPosting job)
    {
        await _context.JobPostings.AddAsync(job);
        await _context.SaveChangesAsync();
    }

    public async Task<List<JobPosting>> GetAllAsync()
    {
        return await _context.JobPostings.ToListAsync();
    }

    public async Task<JobPosting?> GetByIdAsync(int id)
    {
        return await _context.JobPostings.FindAsync(id);
    }

    public async Task<List<JobPosting>> GetByRecruiterIdAsync(int recruiterId)
    {
        return await _context.JobPostings
            .Where(j => j.RecruiterId == recruiterId)
            .ToListAsync();
    }

    public async Task UpdateAsync(JobPosting job)
    {
        _context.JobPostings.Update(job);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(JobPosting job)
    {
        _context.JobPostings.Remove(job);
        await _context.SaveChangesAsync();
    }

    public async Task<int?> GetRecruiterProfileIdByUserIdAsync(int userId)
    {
        return await _context.RecruiterProfiles
            .Where(r => r.UserId == userId)
            .Select(r => (int?)r.Id)
            .FirstOrDefaultAsync();
    }
}