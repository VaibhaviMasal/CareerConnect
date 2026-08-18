using CareerConnect.Application.Features.Applications.Interfaces;
using CareerConnect.Application.Features.Jobs.DTOs;
using CareerConnect.Application.Features.Jobs.Interfaces;
using CareerConnect.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareerConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Recruiter")]
public class JobsController : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly IApplicationService _applicationService;

    public JobsController(
        IJobService jobService,
        IApplicationService applicationService)
    {
        _jobService = jobService;
        _applicationService = applicationService;
    }


    // ✅ CREATE JOB
    [HttpPost]
    public async Task<IActionResult> Create(CreateJobRequestDto request)
    {
        var recruiterId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        await _jobService.CreateJobAsync(request, recruiterId);

        return Ok("Job created successfully");
    }

    // ✅ GET ALL JOBS
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var jobs = await _jobService.GetAllJobsAsync();
        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var job = await _jobService.GetJobByIdAsync(id);
        if (job == null) return NotFound();

        return Ok(job);
    }

    [HttpGet("my")]
    public async Task<IActionResult> GetMyJobs()
    {
        int recruiterId = 3; // TEMP
        var jobs = await _jobService.GetJobsByRecruiterAsync(recruiterId);

        return Ok(jobs);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateJobRequestDto request)
    {
        await _jobService.UpdateJobAsync(id, request);
        return Ok("Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _jobService.DeleteJobAsync(id);
        return Ok("Deleted");
    }
}