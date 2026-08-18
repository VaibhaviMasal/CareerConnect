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
}