using System.ComponentModel.DataAnnotations;

namespace ToolKitAPI.Data.Models;

public class NoteModel
{
    [Key]
    public Guid Id { get; set; }
    
    public string Content { get; set; }
    public string Creator { get; set; }
}
