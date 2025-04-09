using MediatR;
using Xopero.Library.Commands;

namespace Xopero.Library.Handlers;

internal class CloseIssueCommandHandler : IRequestHandler<CloseIssueCommand>
{
    public Task Handle(CloseIssueCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}