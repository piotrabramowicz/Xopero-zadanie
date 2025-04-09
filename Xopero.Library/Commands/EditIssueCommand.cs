using MediatR;
using Xopero.Library.Enums;

namespace Xopero.Library.Commands;

public record EditIssueCommand(
    int Id,
    string Name,
    string Description,
    ApiClient ApiClient) : IRequest<bool>;