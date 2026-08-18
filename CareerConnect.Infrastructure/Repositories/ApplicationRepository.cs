using CareerConnect.Application.Features.Applications.Interfaces;
using CareerConnect.Domain.Entities;
using CareerConnect.Infrastructure.Persistence;

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
        await _context.Applications.AddAsync(application);
        await _context.SaveChangesAsync();
    }
}