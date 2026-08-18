using CareerConnect.Application.Features.Applications.DTOs;
using CareerConnect.Application.Features.Applications.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace CareerConnect.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    // 👇 APPLY JOB
    [HttpPost("apply")]
    //[Authorize(Roles = "Candidate")]
    public async Task<IActionResult> ApplyJob([FromBody] ApplyJobRequestDto dto)
    {
        await _applicationService.ApplyAsync(dto);

        return Ok("Applied successfully");
    }

    [HttpGet("my")]
    public async Task<IActionResult> GetMyApplications()
    {
        var candidateId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _applicationService.GetMyApplicationsAsync(candidateId);

        return Ok(result);
    }

    // GET: api/applications/job/10
    [HttpGet("job/{jobId}")]
    public async Task<IActionResult> GetByJob(int jobId)
    {
        var result = await _applicationService.GetApplicationsByJobAsync(jobId);
        return Ok(result);
    }

    // PUT: api/applications/5/status?status=1
    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, int status)
    {
        await _applicationService.UpdateStatusAsync(id, status);
        return Ok("Status updated");
    }

    // DELETE: api/applications/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _applicationService.DeleteAsync(id);
        return Ok("Deleted successfully");
    }
}