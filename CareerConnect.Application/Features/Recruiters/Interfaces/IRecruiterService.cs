using CareerConnect.Application.Features.Recruiters.DTOs;
namespace CareerConnect.Application.Features.Recruiters.Interfaces
{
    public interface IRecruiterService
    {
        Task CreateAsync(CreateRecruiterDto dto, int userId);
        Task<RecruiterResponseDto> GetMyProfileAsync(int userId);
    }
}
