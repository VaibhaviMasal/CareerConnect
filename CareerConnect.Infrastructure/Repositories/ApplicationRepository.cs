using CareerConnect.Application.Features.Applications.Interfaces;
using CareerConnect.Domain.Entities;
using CareerConnect.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CareerConnect.Infrastructure.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly CareerConnectDbContext _context;

    public ApplicationRepository(CareerConnectDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(JobApplication application)
    {
        await _context.JobApplications.AddAsync(application);
        await _context.SaveChangesAsync();
    }

    
public async Task<List<JobApplication>> GetByCandidateIdAsync(int candidateId)
{
    return await _context.JobApplications
        .Where(a => a.CandidateId == candidateId)
        .Include(a => a.JobPosting)
        .ThenInclude(j => j.Recruiter)
        .ToListAsync();
}

    public async Task<List<JobApplication>> GetByJobIdAsync(int jobId)
    {
        return await _context.JobApplications
            .Where(a => a.JobPostingId == jobId)
            .Include(a => a.Candidate)
            .Include(a => a.Resume)
            .ToListAsync();
    }

    public async Task<JobApplication?> GetByIdAsync(int id)
    {
        return await _context.JobApplications
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task UpdateAsync(JobApplication application)
    {
        _context.JobApplications.Update(application);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(JobApplication application)
    {
        _context.JobApplications.Remove(application);
        await _context.SaveChangesAsync();
    }
}