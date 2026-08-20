using CareerConnect.Application.Features.Candidates.DTOs;
using CareerConnect.Application.Features.Candidates.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class CandidatesController : ControllerBase
{
    private readonly ICandidateService _candidateService;

    public CandidatesController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    // ✅ CREATE
    [HttpPost]
    [Authorize(Roles = "Candidate")]
    public async Task<IActionResult> Create(CreateCandidateDto request)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        await _candidateService.CreateAsync(request, userId);

        return Ok("Candidate profile created");
    }

    // ✅ UPDATE
    [HttpPut]
    [Authorize(Roles = "Candidate")]
    public async Task<IActionResult> Update(UpdateCandidateDto request)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        await _candidateService.UpdateAsync(request, userId);

        return Ok("Candidate updated");
    }

    // ✅ DELETE
    [HttpDelete]
    [Authorize(Roles = "Candidate")]
    public async Task<IActionResult> Delete()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        await _candidateService.DeleteAsync(userId);

        return Ok("Candidate deleted");
    }

    // ✅ GET MY PROFILE
    [HttpGet("me")]
    [Authorize(Roles = "Candidate")]
    public async Task<IActionResult> GetMyProfile()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        var result = await _candidateService.GetMyProfileAsync(userId);

        return Ok(result);
    }

    // ✅ GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _candidateService.GetByIdAsync(id);

        return Ok(result);
    }
}