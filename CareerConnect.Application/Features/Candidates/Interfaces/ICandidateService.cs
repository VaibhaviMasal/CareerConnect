using CareerConnect.Application.Features.Candidates.DTOs;

namespace CareerConnect.Application.Features.Candidates.Interfaces
{
    public interface ICandidateService
    {
        Task CreateAsync(CreateCandidateDto request, int userId);
        Task UpdateAsync(UpdateCandidateDto request, int userId);
        Task DeleteAsync(int userId);
        Task<CandidateResponseDto> GetMyProfileAsync(int userId);
        Task<CandidateResponseDto> GetByIdAsync(int id);
    }
}
