using MediatR;
using Xopero.Library.Enums;

namespace Xopero.Library.Commands;

public record CloseIssueCommand(
    int Id,
    ApiClient ApiClient) : IRequest<bool>;