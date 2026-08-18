using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Authentication.Interfaces;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken refreshToken);

    Task<RefreshToken?> GetByTokenAsync(string token);

    Task UpdateAsync(RefreshToken refreshToken);
}