using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using MediatR;
using Xopero.Library.Commands;

namespace Xopero.Library.Handlers;

internal class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand>
{
    public async Task Handle(CreateIssueCommand request, CancellationToken cancellationToken)
    {
        //token github
        //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

        // Przygotowanie klienta
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MyApp", "1.0"));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "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");
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));

        // 1. Stwórz nowe issue
        var newIssue = new
        {
            title = "Bug in production",
            body = "Details about the bug...",
            assignees = new[] { "username" },
            labels = new[] { "bug" }
        };

        var content = new StringContent(JsonSerializer.Serialize(newIssue), Encoding.UTF8, "application/json");
        var createResponse = await httpClient.PostAsync("https://api.github.com/repos/{owner}/{repo}/issues", content);
        var createResult = await createResponse.Content.ReadAsStringAsync();
        Console.WriteLine(createResult);
    }
}