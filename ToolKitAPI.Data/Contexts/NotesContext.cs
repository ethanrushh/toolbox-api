using Microsoft.EntityFrameworkCore;
using ToolKitAPI.Data.Models;

namespace ToolKitAPI.Data.Contexts;

public class NotesContext : DbContext
{
    public DbSet<NoteModel> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("NotesDb"); // TODO Change into a MySQL or database or similar
        
        base.OnConfiguring(optionsBuilder);
    }
}
