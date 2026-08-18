using CareerConnect.Application.Features.Interviews.DTOs;
using CareerConnect.Application.Features.Interviews.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CareerConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InterviewsController : ControllerBase
{
    private readonly IInterviewService _service;

    public InterviewsController(IInterviewService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Schedule(ScheduleInterviewRequestDto dto)
    {
        await _service.ScheduleAsync(dto);
        return Ok("Interview Scheduled");
    }

    [HttpGet("application/{applicationId}")]
    public async Task<IActionResult> GetByApplication(int applicationId)
    {
        var result = await _service.GetByApplicationAsync(applicationId);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromQuery] string status)
    {
        await _service.UpdateStatusAsync(id, status);
        return Ok("Status updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok("Deleted");
    }
}