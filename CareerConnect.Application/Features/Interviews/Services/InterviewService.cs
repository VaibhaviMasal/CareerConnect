using CareerConnect.Application.Features.Interviews.DTOs;
using CareerConnect.Application.Features.Interviews.Interfaces;
using CareerConnect.Domain.Entities;

namespace CareerConnect.Application.Features.Interviews.Services;

public class InterviewService : IInterviewService
{
    private readonly IInterviewRepository _repository;

    public InterviewService(IInterviewRepository repository)
    {
        _repository = repository;
    }

    public async Task ScheduleAsync(ScheduleInterviewRequestDto dto)
    {
        var interview = new InterviewSchedule
        {
            ApplicationId = dto.ApplicationId,
            ScheduledAt = dto.ScheduledAt,
            Mode = dto.Mode,
            MeetingLink = dto.MeetingLink,
            Status = "Scheduled",
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(interview);
    }

    public async Task<List<InterviewResponseDto>> GetByApplicationAsync(int applicationId)
    {
        var data = await _repository.GetByApplicationIdAsync(applicationId);

        return data.Select(i => new InterviewResponseDto
        {
            Id = i.Id,
            ApplicationId = i.ApplicationId,
            ScheduledAt = i.ScheduledAt,
            Mode = i.Mode,
            Status = i.Status
        }).ToList();
    }

    public async Task<List<InterviewResponseDto>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();

        return data.Select(i => new InterviewResponseDto
        {
            Id = i.Id,
            ApplicationId = i.ApplicationId,
            ScheduledAt = i.ScheduledAt,
            Mode = i.Mode,
            Status = i.Status
        }).ToList();
    }

    public async Task UpdateStatusAsync(int id, string status)
    {
        var interview = await _repository.GetByIdAsync(id);

        if (interview == null)
            throw new Exception("Interview not found");

        interview.Status = status;

        await _repository.UpdateAsync(interview);
    }

    public async Task DeleteAsync(int id)
    {
        var interview = await _repository.GetByIdAsync(id);

        if (interview == null)
            throw new Exception("Interview not found");

        await _repository.DeleteAsync(interview);
    }
}