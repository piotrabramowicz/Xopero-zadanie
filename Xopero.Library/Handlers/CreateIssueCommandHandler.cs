using MediatR;
using Xopero.Library.Commands;

namespace Xopero.Library.Handlers;

internal class CreateIssueCommandHandler(IServiceProvider serviceProvider) : CommandHandlerBase(serviceProvider), IRequestHandler<CreateIssueCommand, bool>
{
    public async Task<bool> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
    {
        return await GetApiClient(request.ApiClient)
            .CreateIssue(request.Name, request.Description);
    }
}