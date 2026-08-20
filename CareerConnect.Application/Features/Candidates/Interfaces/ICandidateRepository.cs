using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Candidates.Interfaces
{
    public interface ICandidateRepository
    {
        Task AddAsync(CandidateProfile candidate);
        Task<CandidateProfile?> GetByUserIdAsync(int userId);
        Task<CandidateProfile?> GetByIdAsync(int id);
        Task UpdateAsync(CandidateProfile candidate);
        Task DeleteAsync(CandidateProfile candidate);
    }
}
