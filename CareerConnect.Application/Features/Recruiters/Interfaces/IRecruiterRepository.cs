using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Recruiters.Interfaces
{
    using CareerConnect.Domain.Entities;

    public interface IRecruiterRepository
    {
        Task<RecruiterProfile?> GetByUserIdAsync(int userId);
        Task AddAsync(RecruiterProfile profile);
    }
}
