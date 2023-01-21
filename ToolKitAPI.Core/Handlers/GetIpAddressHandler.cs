using MediatR;
using ToolKitAPI.Core.Queries;

namespace ToolKitAPI.Core.Handlers;

public class GetIpAddressHandler : IRequestHandler<GetIpAddressQuery, string>
{
    public Task<string> Handle(GetIpAddressQuery request, CancellationToken cancellationToken) => Task.FromResult($"{(request.ip is null ? "(no IPV4 address)" : request.ip.MapToIPv4())}");
}
