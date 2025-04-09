using MediatR;
using Xopero.Library.Commands;

namespace Xopero.Library.Handlers;

internal class EditIssueCommandHandler(IServiceProvider serviceProvider) : CommandHandlerBase(serviceProvider), IRequestHandler<EditIssueCommand, bool>
{
    public async Task<bool> Handle(EditIssueCommand request, CancellationToken cancellationToken)
    {
        return await GetApiClient(request.ApiClient)
            .EditIssue(request.Id, request.Name, request.Description);
    }
}