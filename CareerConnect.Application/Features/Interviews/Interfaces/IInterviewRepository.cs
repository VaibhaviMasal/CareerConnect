using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Interviews.Interfaces;

public interface IInterviewRepository
{
    Task AddAsync(InterviewSchedule interview);
    Task<List<InterviewSchedule>> GetByApplicationIdAsync(int applicationId);
    Task<List<InterviewSchedule>> GetAllAsync();
    Task<InterviewSchedule?> GetByIdAsync(int id);
    Task UpdateAsync(InterviewSchedule interview);
    Task DeleteAsync(InterviewSchedule interview);
}