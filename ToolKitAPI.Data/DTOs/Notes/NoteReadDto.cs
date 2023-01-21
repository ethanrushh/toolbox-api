namespace ToolKitAPI.Data.DTOs.Notes;

public class NoteReadDto
{
    public Guid Id { get; set; }
    
    public string Content { get; set; }
    public string Creator { get; set; }
}