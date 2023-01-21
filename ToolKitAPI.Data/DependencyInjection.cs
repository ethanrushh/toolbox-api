using Microsoft.Extensions.DependencyInjection;
using ToolKitAPI.Data.Contexts;
using ToolKitAPI.Data.DTOs.Notes;
using ToolKitAPI.Data.Models;
using ToolKitAPI.Data.Services;

namespace ToolKitAPI.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDataServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(x =>
        {
            x.CreateMap<NoteModel, NoteReadDto>();
        });

        serviceCollection.AddDbContext<NotesContext>();

        serviceCollection.AddScoped<NotesService>();

        return serviceCollection;
    }
}
