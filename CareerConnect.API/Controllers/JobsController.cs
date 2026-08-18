using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CareerConnect.Infrastructure.Persistence;
using CareerConnect.Domain.Entities;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly CareerConnectDbContext _context;

    public JobsController(CareerConnectDbContext context)
    {
        _context = context;
    }

    // 🔐 Recruiter only
    [Authorize(Roles = "Recruiter")]
    [HttpPost]
    public async Task<IActionResult> CreateJob(CreateJobRequestDto request)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var job = new Job
        {
            Title = request.Title,
            Description = request.Description,
            Location = request.Location,
            Salary = request.Salary,
            CreatedBy = userId
        };

        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();

        return Ok(job);
    }

    // 👀 Anyone logged in
    [Authorize]
    [HttpGet]
    public IActionResult GetAllJobs()
    {
        return Ok(_context.Jobs.ToList());
    }
}