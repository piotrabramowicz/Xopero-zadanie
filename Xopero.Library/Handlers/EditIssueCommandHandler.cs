using MediatR;
using Xopero.Library.Commands;

namespace Xopero.Library.Handlers;

internal class EditIssueCommandHandler : IRequestHandler<EditIssueCommand>
{
    public Task Handle(EditIssueCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}