using CareerConnect.Application.Features.Interviews.Interfaces;
using CareerConnect.Domain.Entities;
using CareerConnect.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CareerConnect.Infrastructure.Repositories;

public class InterviewRepository : IInterviewRepository
{
    private readonly CareerConnectDbContext _context;

    public InterviewRepository(CareerConnectDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(InterviewSchedule interview)
    {
        await _context.InterviewSchedules.AddAsync(interview);
        await _context.SaveChangesAsync();
    }

    public async Task<List<InterviewSchedule>> GetByApplicationIdAsync(int applicationId)
    {
        return await _context.InterviewSchedules
            .Where(i => i.ApplicationId == applicationId)
            .ToListAsync();
    }

    public async Task<List<InterviewSchedule>> GetAllAsync()
    {
        return await _context.InterviewSchedules.ToListAsync();
    }

    public async Task<InterviewSchedule?> GetByIdAsync(int id)
    {
        return await _context.InterviewSchedules.FindAsync(id);
    }

    public async Task UpdateAsync(InterviewSchedule interview)
    {
        _context.InterviewSchedules.Update(interview);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(InterviewSchedule interview)
    {
        _context.InterviewSchedules.Remove(interview);
        await _context.SaveChangesAsync();
    }
}