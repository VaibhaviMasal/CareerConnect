using CareerConnect.Application.Features.Interviews.DTOs;

namespace CareerConnect.Application.Features.Interviews.Interfaces;

public interface IInterviewService
{
    Task ScheduleAsync(ScheduleInterviewRequestDto dto);
    Task<List<InterviewResponseDto>> GetByApplicationAsync(int applicationId);
    Task<List<InterviewResponseDto>> GetAllAsync();
    Task UpdateStatusAsync(int id, string status);
    Task DeleteAsync(int id);
}