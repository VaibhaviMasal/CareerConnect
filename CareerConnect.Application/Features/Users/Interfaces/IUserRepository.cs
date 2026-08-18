using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Users.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);

    Task AddAsync(User user);
}