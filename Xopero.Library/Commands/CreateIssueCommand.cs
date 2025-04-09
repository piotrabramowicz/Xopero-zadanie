using MediatR;
using Xopero.Library.Enums;

namespace Xopero.Library.Commands;

public record CreateIssueCommand(
    string Name,
    string Description,
    ApiClient ApiClient) : IRequest;