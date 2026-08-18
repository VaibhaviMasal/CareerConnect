using CareerConnect.Application.Features.Jobs.Interfaces;
using CareerConnect.Domain.Entities;
using CareerConnect.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class JobRepository : IJobRepository
{
    private readonly CareerConnectDbContext _context;

    public JobRepository(CareerConnectDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Job job)
    {
        await _context.Jobs.AddAsync(job);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Job>> GetAllAsync()
    {
        return await _context.Jobs.ToListAsync();
    }

    public async Task<Job?> GetByIdAsync(int id)
    {
        return await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id);
    }

    public async Task<List<Job>> GetByRecruiterIdAsync(int recruiterId)
    {
        return await _context.Jobs
            .Where(j => j.RecruiterId == recruiterId)
            .ToListAsync();
    }

    public async Task UpdateAsync(Job job)
    {
        _context.Jobs.Update(job);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Job job)
    {
        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
    }
}