using CareerConnect.Application.Features.Candidates.DTOs;

namespace CareerConnect.Application.Features.Candidates.Interfaces
{
    public interface ICandidateService
    {
        Task CreateAsync(CreateCandidateDto dto, int userId);
        Task<CandidateResponseDto> GetMyProfileAsync(int userId);
    }
}
