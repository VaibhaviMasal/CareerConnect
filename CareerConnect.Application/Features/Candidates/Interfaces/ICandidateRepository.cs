using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Candidates.Interfaces
{
    public interface ICandidateRepository
    {
        Task<CandidateProfile?> GetByUserIdAsync(int userId);
        Task AddAsync(CandidateProfile profile);
    }
}
