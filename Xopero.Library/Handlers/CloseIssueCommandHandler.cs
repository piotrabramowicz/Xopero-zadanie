using MediatR;
using Xopero.Library.Commands;

namespace Xopero.Library.Handlers;

internal class CloseIssueCommandHandler(IServiceProvider serviceProvider) : CommandHandlerBase(serviceProvider), IRequestHandler<CloseIssueCommand, bool>
{
    public async Task<bool> Handle(CloseIssueCommand request, CancellationToken cancellationToken)
    {
        return await GetApiClient(request.ApiClient)
            .CloseIssue(request.Id);
    }
}