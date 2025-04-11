using System.Text.Json;

namespace Xopero.Library.Clients;

internal sealed class GitHubApiClient : ApiClientBase, IApiClient
{
    protected override string Token => "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";
    protected override string MediaType => "application/vnd.github+json";
    protected override string BaseUrl => "https://api.github.com/repos/piotrabramowicz/Spoon-Knife/issues";

    public async Task<bool> CreateIssue(string name, string description)
    {
        var newIssue = new 
        {
            title = name,
            body = description,
            assignees = new[] { "piotrabramowicz" },
            labels = new[] { "bug" }
        };

        return await PostAsync(
            BaseUrl, 
            CreateStringContent(JsonSerializer.Serialize(newIssue)));
    }

    public async Task<bool> EditIssue(int id, string name, string description)
    {
        var editIssue = new 
        {
            title = name,
            body = description,
            state = "Open",
        };

        return await PatchAsync(
            $"{BaseUrl}/{id}", 
            CreateStringContent(JsonSerializer.Serialize(editIssue)));
    }

    public async Task<bool> CloseIssue(int id)
    {
        var editIssue = new
        {
            state = "closed",
        };

        return await PatchAsync(
            $"{BaseUrl}/{id}", 
            CreateStringContent(JsonSerializer.Serialize(editIssue)));
    }
}
