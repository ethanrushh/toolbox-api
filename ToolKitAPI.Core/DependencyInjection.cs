using FluentValidation;
using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ToolKitAPI.Core.Exceptions;

namespace ToolKitAPI.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection serviceCollection)
    {
        var localAssembly = typeof(DependencyInjection).Assembly;

        serviceCollection.AddMediatR(localAssembly);


        serviceCollection.AddProblemDetails(x =>
        {
            x.IncludeExceptionDetails = (_, _) => false;
            
            x.Map<NotFoundInDatabaseException>(ex => new StatusCodeProblemDetails(StatusCodes.Status404NotFound)
            {
                Detail = ex.Message
            });
        });

        serviceCollection.AddValidatorsFromAssembly(localAssembly);
        serviceCollection.AddFluentValidationAutoValidation();

        return serviceCollection;
    }
}
