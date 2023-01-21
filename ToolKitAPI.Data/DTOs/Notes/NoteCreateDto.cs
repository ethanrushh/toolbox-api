namespace ToolKitAPI.Data.DTOs.Notes;

[Obsolete("These properties are already covered by the command")]
public class NoteCreateDto
{
    public string Content { get; set; }
    public string Creator { get; set; }
}