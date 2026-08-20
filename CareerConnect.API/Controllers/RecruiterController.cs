using CareerConnect.Application.Features.Recruiters.DTOs;
using CareerConnect.Application.Features.Recruiters.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareerConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecruitersController : ControllerBase
{
    private readonly IRecruiterService _recruiterService;

    public RecruitersController(IRecruiterService recruiterService)
    {
        _recruiterService = recruiterService;
    }

    // =========================
    // CREATE RECRUITER PROFILE
    // =========================
    [HttpPost]
    [Authorize(Roles = "Recruiter")]
    public async Task<IActionResult> Create(CreateRecruiterDto request)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        await _recruiterService.CreateAsync(request, userId);

        return Ok("Recruiter profile created successfully");
    }

    // =========================
    // GET MY PROFILE
    // =========================
    [HttpGet("me")]
    [Authorize(Roles = "Recruiter")]
    public async Task<IActionResult> GetMyProfile()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _recruiterService.GetByUserIdAsync(userId);

        return Ok(result);
    }

    // =========================
    // GET BY ID
    // =========================
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _recruiterService.GetByIdAsync(id);

        return Ok(result);
    }

    // =========================
    // UPDATE
    // =========================
    [HttpPut]
    [Authorize(Roles = "Recruiter")]
    public async Task<IActionResult> Update(UpdateRecruiterDto request)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        await _recruiterService.UpdateAsync(userId, request);

        return Ok("Recruiter updated successfully");
    }

    // =========================
    // DELETE
    // =========================
    [HttpDelete]
    [Authorize(Roles = "Recruiter")]
    public async Task<IActionResult> Delete()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        await _recruiterService.DeleteAsync(userId);

        return Ok("Recruiter deleted successfully");
    }
}