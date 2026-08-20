using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Recruiters.Interfaces
{
    using CareerConnect.Domain.Entities;

    using CareerConnect.Domain.Entities;

    public interface IRecruiterRepository
    {
        Task AddAsync(RecruiterProfile recruiter);
        Task<RecruiterProfile?> GetByUserIdAsync(int userId);
        Task<RecruiterProfile?> GetByIdAsync(int id);
        Task UpdateAsync(RecruiterProfile recruiter);
        Task DeleteAsync(RecruiterProfile recruiter);
    }
}
