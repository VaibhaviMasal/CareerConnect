using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Users.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);

    Task AddAsync(User user);


    Task<User?> GetByIdAsync(int id);

    Task<List<User>> GetAllAsync();


    Task UpdateAsync(User user);


}