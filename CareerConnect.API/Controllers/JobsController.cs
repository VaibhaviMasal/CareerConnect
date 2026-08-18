using CareerConnect.Application.Features.Applications.Interfaces;
using CareerConnect.Application.Features.Jobs.Interfaces;
using CareerConnect.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CareerConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobsController(IJobService jobService)
    {
        _jobService = jobService;
    }
    private readonly IApplicationService _applicationService;

    // ✅ CREATE JOB
    [HttpPost]
    public async Task<IActionResult> CreateJob([FromBody] JobPosting job)
    {
        await _jobService.CreateJobAsync(job);
        return Ok("Job created successfully");
    }

    // ✅ GET ALL JOBS
    [HttpGet]
    public async Task<IActionResult> GetAllJobs()
    {
        var jobs = await _jobService.GetAllJobsAsync();
        return Ok(jobs);
    }

    // ✅ GET JOB BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetJobById(int id)
    {
        var job = await _jobService.GetJobByIdAsync(id);

        if (job == null)
            return NotFound();

        return Ok(job);
    }


    [HttpGet("my")]
    public async Task<IActionResult> GetMyApplications()
    {
        // for now hardcode (we'll fix auth later)
        int candidateId = 1;

        var result = await _applicationService.GetMyApplicationsAsync(candidateId);

        return Ok(result);
    }
}