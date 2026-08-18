using CareerConnect.Application.Features.Applications.DTOs;

namespace CareerConnect.Application.Features.Applications.Interfaces;

public interface IApplicationService
{
    Task ApplyAsync(ApplyJobRequestDto dto);

    Task<List<ApplicationResponseDto>> GetMyApplicationsAsync(int candidateId);

    Task<List<ApplicationResponseDto>> GetApplicationsByJobAsync(int jobId);
    Task UpdateStatusAsync(int id, int status);
    Task DeleteAsync(int id);
}