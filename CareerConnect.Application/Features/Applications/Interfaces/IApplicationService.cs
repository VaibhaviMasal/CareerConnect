using CareerConnect.Application.Features.Applications.DTOs;

namespace CareerConnect.Application.Features.Applications.Interfaces;

public interface IApplicationService
{
    Task ApplyAsync(CreateApplicationDto request, int userId);

    Task<List<ApplicationResponseDto>> GetMyApplicationsAsync(int userId);

    Task<List<ApplicationResponseDto>> GetByJobIdAsync(int jobId);

    Task UpdateStatusAsync(int id, string status);

    Task DeleteAsync(int id);
}