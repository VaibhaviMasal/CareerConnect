public class UpdateJobRequestDto
{
    public required string Title { get; set; } = string.Empty;
    public required string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int MinExperience { get; set; }
    public int MaxExperience { get; set; }
}