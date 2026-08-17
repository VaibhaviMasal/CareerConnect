using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);

    Task AddAsync(User user);
}