using Xopero.Library.Enums;

namespace Xopero.API.Controllers.Issues.Models;

public record IssueApiDto
{
    public ApiClient ApiClient { get; set; }
}