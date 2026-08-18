using CareerConnect.Application.Features.Applications.DTOs;
using CareerConnect.Application.Features.Applications.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareerConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    // APPLY
    [Authorize(Roles = "Candidate")]
    [HttpPost("apply")]
    public async Task<IActionResult> Apply(CreateApplicationDto request)
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdStr == null)
            return Unauthorized();

        int userId = int.Parse(userIdStr);

        await _applicationService.ApplyAsync(request, userId);

        return Ok("Applied successfully");
    }

    // MY APPLICATIONS
    [Authorize(Roles = "Candidate")]
    [HttpGet("my")]
    public async Task<IActionResult> My()
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdStr == null)
            return Unauthorized();

        int userId = int.Parse(userIdStr);

        var data = await _applicationService.GetMyApplicationsAsync(userId);

        return Ok(data);
    }

    // GET BY JOB
    [Authorize(Roles = "Recruiter")]
    [HttpGet("job/{jobId}")]
    public async Task<IActionResult> GetByJob(int jobId)
    {
        var data = await _applicationService.GetByJobIdAsync(jobId);

        return Ok(data);
    }

    // UPDATE STATUS
    [Authorize(Roles = "Recruiter")]
    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, UpdateStatusDto request)
    {
        await _applicationService.UpdateStatusAsync(id, request.Status);

        return Ok("Updated");
    }

    // DELETE
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _applicationService.DeleteAsync(id);

        return Ok("Deleted");
    }
}