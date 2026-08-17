namespace CareerConnect.Application.DTOs.Authentication;

public class RegisterRequestDto
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int Role { get; set; } // 1 = Admin, 2 = Recruiter, 3 = Candidate
}