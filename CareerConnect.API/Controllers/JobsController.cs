using CareerConnect.Application.Features.Jobs.DTOs;
using CareerConnect.Application.Features.Jobs.Interfaces;
using CareerConnect.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobsController(IJobService jobService)
    {
        _jobService = jobService;
    }

    // 🔐 RECRUITER ONLY → Create Job
    [HttpPost]
    [Authorize(Roles = "Recruiter")]
    public async Task<IActionResult> CreateJob(CreateJobRequest request)
    {
        await _jobService.AddAsync(request, User);
        return Ok("Job created successfully");
    }

    // 🌍 PUBLIC → Get all jobs
    [HttpGet]
    public async Task<IActionResult> GetAllJobs()
    {
        var jobs = await _jobService.GetAllJobsAsync();
        return Ok(jobs);
    }

    // 🌍 PUBLIC → Get job by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetJobById(int id)
    {
        var job = await _jobService.GetJobByIdAsync(id);

        if (job == null)
            return NotFound();

        return Ok(job);
    }

    // 🔐 RECRUITER → Get own jobs
    [HttpGet("my-jobs")]
    [Authorize(Roles = "Recruiter")]
    public async Task<IActionResult> GetMyJobs()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var jobs = await _jobService.GetJobsByRecruiterAsync(userId);

        return Ok(jobs);
    }

    // 🔐 RECRUITER → Update job
    [HttpPut("{id}")]
    [Authorize(Roles = "Recruiter")]
    public async Task<IActionResult> UpdateJob(int id, [FromBody] Job job)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        job.Id = id;
        job.RecruiterId = userId;

        await _jobService.UpdateJobAsync(job);

        return Ok("Job updated");
    }

    // 🔐 RECRUITER → Delete job
    [HttpDelete("{id}")]
    [Authorize(Roles = "Recruiter")]
    public async Task<IActionResult> DeleteJob(int id)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        await _jobService.DeleteJobAsync(id, userId);

        return Ok("Job deleted");
    }
}