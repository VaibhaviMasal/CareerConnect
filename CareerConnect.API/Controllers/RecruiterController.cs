
using CareerConnect.Application.Features.Recruiters.DTOs;
using CareerConnect.Application.Features.Recruiters.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareerConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Recruiter")]
public class RecruitersController : ControllerBase
{
    private readonly IRecruiterService _service;

    public RecruitersController(IRecruiterService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRecruiterDto dto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        await _service.CreateAsync(dto, userId);

        return Ok("Recruiter profile created");
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMyProfile()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var data = await _service.GetMyProfileAsync(userId);

        return Ok(data);
    }
}