using CareerConnect.Application.Features.Users.DTOs;
using CareerConnect.Application.Features.Users.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    // ✅ GET USER BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _service.GetByIdAsync(id);
        return Ok(user);
    }

    // ✅ UPDATE USER
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserDto request)
    {
        await _service.UpdateAsync(id, request);
        return Ok("User updated");
    }

    // ✅ DELETE USER
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok("User deleted");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _service.GetAllAsync();
        return Ok(users);
    }
}