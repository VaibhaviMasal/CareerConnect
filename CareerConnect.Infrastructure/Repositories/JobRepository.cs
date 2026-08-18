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

    public async Task<List<JobPosting>> GetAllJobsAsync()
    {
        return await _context.JobPostings.ToListAsync();
    }

    public async Task<JobPosting?> GetByIdAsync(int id)
    {
        return await _context.JobPostings.FindAsync(id);
    }
}