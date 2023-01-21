using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ToolKitAPI.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection serviceCollection)
    {
        var localAssembly = typeof(DependencyInjection).Assembly;

        serviceCollection.AddMediatR(localAssembly);
        
        
        return serviceCollection;
    }
}
