public class JobResponseDto
{
    public int Id { get; set; }
    public int RecruiterId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int MinExperience { get; set; }
    public int MaxExperience { get; set; }
}