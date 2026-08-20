using CareerConnect.Application.Features.Resumes.DTOs;

public interface IResumeService
{
    Task UploadAsync(UploadResumeDto request, int userId);
    Task<List<ResumeResponseDto>> GetMyResumesAsync(int userId);
    Task UpdateAsync(UpdateResumeDto request, int userId);
    Task DeleteAsync(int resumeId, int userId);
}