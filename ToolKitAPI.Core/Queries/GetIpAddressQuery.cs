using System.Net;
using MediatR;

namespace ToolKitAPI.Core.Queries;

public record GetIpAddressQuery(IPAddress? ip) : IRequest<string>;