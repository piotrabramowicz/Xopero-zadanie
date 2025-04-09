namespace Xopero.Library.Clients;

internal interface IApiClient
{
    Task<bool> CreateIssue(string Name, string Description);

    Task<bool> EditIssue(int id, string name, string description);

    Task<bool> CloseIssue(int id);
}