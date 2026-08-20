
using CareerConnect.Application.Features.Resumes.DTOs;
using CareerConnect.Application.Features.Resumes.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareerConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResumesController : ControllerBase
{
    private readonly IResumeService _resumeService;

    public ResumesController(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }


    [HttpPost("upload")]
    [Authorize(Roles = "Candidate")]
    public async Task<IActionResult> Upload([FromForm] UploadResumeDto request)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        await _resumeService.UploadAsync(request, userId);

        return Ok("Resume uploaded");
    }

    // 📄 Get My Resumes
    [Authorize(Roles = "Candidate")]
    [HttpGet("me")]
    public async Task<IActionResult> GetMyResumes()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var data = await _resumeService.GetMyResumesAsync(userId);

        return Ok(data);
    }

    // ✏️ Update Resume
    [Authorize(Roles = "Candidate")]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateResumeDto request)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        await _resumeService.UpdateAsync(request, userId);

        return Ok("Resume updated");
    }

    // ❌ Delete Resume
    [Authorize(Roles = "Candidate")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        await _resumeService.DeleteAsync(id, userId);

        return Ok("Resume deleted");
    }

    
}