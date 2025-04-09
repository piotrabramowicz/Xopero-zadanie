using Microsoft.Extensions.DependencyInjection;
using Xopero.Library.Clients;
using Xopero.Library.Enums;

namespace Xopero.Library.Handlers;

internal abstract class CommandHandlerBase(IServiceProvider serviceProvider)
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    protected IApiClient GetApiClient(ApiClient apiClient)
    {
        return _serviceProvider.GetRequiredKeyedService<IApiClient>(apiClient.ToString());
    }
}