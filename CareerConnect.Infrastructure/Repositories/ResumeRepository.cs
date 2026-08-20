
using CareerConnect.Application.Features.Resumes.Interfaces;
using CareerConnect.Domain.Entities;
using CareerConnect.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace CareerConnect.Infrastructure.Repositories;

public class ResumeRepository : IResumeRepository
{
    private readonly CareerConnectDbContext _context;

    public ResumeRepository(CareerConnectDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Resume resume)
    {
        await _context.Resumes.AddAsync(resume);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Resume>> GetByCandidateIdAsync(int candidateId)
    {
        return await _context.Resumes
            .Where(r => r.CandidateId == candidateId)
            .ToListAsync();
    }

    public async Task<Resume?> GetByIdAsync(int id)
    {
        return await _context.Resumes.FindAsync(id);
    }

    public async Task UpdateAsync(Resume resume)
    {
        _context.Resumes.Update(resume);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Resume resume)
    {
        _context.Resumes.Remove(resume);
        await _context.SaveChangesAsync();
    }
}