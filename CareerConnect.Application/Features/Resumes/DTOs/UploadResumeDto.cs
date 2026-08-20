

using Microsoft.AspNetCore.Http;

namespace CareerConnect.Application.Features.Resumes.DTOs
{
  
    public class UploadResumeDto
    {
        public IFormFile File { get; set; }
    }
}
