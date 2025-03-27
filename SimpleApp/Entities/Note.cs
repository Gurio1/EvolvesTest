namespace SimpleApp.Entities;

public class Note
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public required string Title { get; set; }
    public required string Content { get; set; }
}