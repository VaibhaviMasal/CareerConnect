using CareerConnect.Application.Features.Applications.DTOs;

namespace CareerConnect.Application.Features.Applications.Interfaces;

public interface IApplicationService
{
    Task ApplyAsync(ApplyJobRequestDto dto);

    Task<List<ApplicationResponseDto>> GetMyApplicationsAsync(int candidateId);
}