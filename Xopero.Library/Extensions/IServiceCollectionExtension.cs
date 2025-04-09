using Microsoft.Extensions.DependencyInjection;
using Xopero.Library.Clients;
using Xopero.Library.Enums;

namespace Xopero.Library.Extensions;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddLibraryDependencies(this IServiceCollection services)
    {
        services.AddKeyedTransient<IApiClient, GitHubApiClient>(ApiClient.GitHub.ToString());
        services.AddKeyedTransient<IApiClient, GitLabApiClient>(ApiClient.GitLab.ToString());

        return services;
    }
}