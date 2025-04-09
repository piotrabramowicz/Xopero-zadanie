namespace Xopero.API.Controllers.Issues.Models;

public record EditIssueDto : CreateIssueDto
{
    public Guid Id { get; set; }
}