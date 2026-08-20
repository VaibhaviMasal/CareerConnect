using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Resumes.Interfaces
{
    public interface IResumeRepository
    {
        Task<List<Resume>> GetByCandidateIdAsync(int candidateId);
        Task<Resume?> GetByIdAsync(int id);
        Task AddAsync(Resume resume);
        Task UpdateAsync(Resume resume);
        Task DeleteAsync(Resume resume);
    }
}
