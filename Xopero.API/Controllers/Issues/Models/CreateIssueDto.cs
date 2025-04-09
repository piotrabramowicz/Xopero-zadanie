using Xopero.Library.Enums;

namespace Xopero.API.Controllers.Issues.Models;

public record CreateIssueDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ApiClient ApiClient { get; set; }
}