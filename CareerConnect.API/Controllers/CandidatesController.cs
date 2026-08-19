using CareerConnect.Application.Features.Candidates.DTOs;
using CareerConnect.Application.Features.Candidates.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareerConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidatesController : ControllerBase
{
    private readonly ICandidateService _candidateService;

    public CandidatesController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    // ✅ CREATE PROFILE
    [Authorize(Roles = "Candidate")]
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateCandidateDto request)
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdStr == null)
            return Unauthorized();

        int userId = int.Parse(userIdStr);

        await _candidateService.CreateAsync(request, userId);

        return Ok("Profile created successfully");
    }

    // ✅ GET MY PROFILE
    [Authorize(Roles = "Candidate")]
    [HttpGet("me")]
    public async Task<IActionResult> GetMyProfile()
    {
        var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdStr == null)
            return Unauthorized();

        int userId = int.Parse(userIdStr);

        var data = await _candidateService.GetMyProfileAsync(userId);

        return Ok(data);
    }
}