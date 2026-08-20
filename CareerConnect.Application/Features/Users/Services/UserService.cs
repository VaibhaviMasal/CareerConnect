using CareerConnect.Application.Features.Users.DTOs;
using CareerConnect.Application.Features.Users.Interfaces;

namespace CareerConnect.Application.Features.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    // ✅ GET BY ID
    public async Task<UserResponseDto> GetByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            throw new Exception("User not found");

        return new UserResponseDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = user.Role.ToString()
        };
    }

    // ✅ UPDATE
    public async Task UpdateAsync(int id, UpdateUserDto request)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            throw new Exception("User not found");

        user.FullName = request.FullName;
        user.Email = request.Email;

        await _repository.UpdateAsync(user);
    }

    // ✅ DELETE (SOFT DELETE)
    public async Task DeleteAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            throw new Exception("User not found");

        user.IsActive = false;

        await _repository.UpdateAsync(user);
    }

    public async Task<List<UserResponseDto>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();

        return users.Select(u => new UserResponseDto
        {
            Id = u.Id,
            FullName = u.FullName,
            Email = u.Email,
            Role = u.Role.ToString()
        }).ToList();
    }
}