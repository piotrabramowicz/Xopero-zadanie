namespace Xopero.API.Controllers.Issues.Models;

public record IssueDto: IssueApiDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}