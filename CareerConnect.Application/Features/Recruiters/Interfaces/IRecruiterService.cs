using CareerConnect.Application.Features.Recruiters.DTOs;

namespace CareerConnect.Application.Features.Recruiters.Interfaces
{
    public interface IRecruiterService
    {
        Task CreateAsync(CreateRecruiterDto request, int userId);

        Task<RecruiterResponseDto> GetByUserIdAsync(int userId);
        Task<RecruiterResponseDto> GetByIdAsync(int id);

        Task UpdateAsync(int userId, UpdateRecruiterDto request); // ✅ correct order
        Task DeleteAsync(int userId);
    }
}
