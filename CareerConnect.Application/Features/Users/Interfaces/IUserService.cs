using CareerConnect.Application.Features.Users.DTOs;

namespace CareerConnect.Application.Features.Users.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> GetByIdAsync(int id);
        Task<List<UserResponseDto>> GetAllAsync();
    }
}
