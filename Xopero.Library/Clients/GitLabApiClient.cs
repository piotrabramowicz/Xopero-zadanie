using System.Text.Json;

namespace Xopero.Library.Clients;

internal sealed class GitLabApiClient : ApiClientBase, IApiClient
{
    private const string ProjectId = "68822705";

    protected override string BaseUrl => "https://gitlab.com/api/v4";
    protected override string Token => "glpat-v3CKXNbxwUz_RSaYYy_X";
    protected override string MediaType => "application/json";

    public async Task<bool> CreateIssue(string name, string description)
    {
        var newIssue = new
        {
            title = name,
            description = description,
            labels = "bug", 
            assignee_ids = new[] { 123456 } 
        };

        return await PostAsync(
            $"{BaseUrl}/projects/{ProjectId}/issues",
            CreateStringContent(JsonSerializer.Serialize(newIssue)));
    }

    public async Task<bool> EditIssue(int id, string name, string description)
    {
        var editIssue = new
        {
            title = name,
            description = description,
            state_event = "reopen"
        };

        return await PutAsync(
            $"{BaseUrl}/projects/{ProjectId}/issues/{id}",
            CreateStringContent(JsonSerializer.Serialize(editIssue)));
    }

    public async Task<bool> CloseIssue(int id)
    {
        var closeIssue = new
        {
            state_event = "close"
        };

        return await PutAsync(
            $"{BaseUrl}/projects/{ProjectId}/issues/{id}",
            CreateStringContent(JsonSerializer.Serialize(closeIssue)));
    }
}