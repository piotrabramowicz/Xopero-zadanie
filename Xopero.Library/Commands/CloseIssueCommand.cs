using MediatR;

namespace Xopero.Library.Commands;

public record CloseIssueCommand(Guid Id) : IRequest;