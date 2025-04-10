using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xopero.API.Controllers.Issues.Models;
using Xopero.Library.Commands;
using Xopero.Library.Enums;

namespace Xopero.API.Controllers.Issues;

[ApiController]
[Route("[controller]")]
public class IssuesController(IMediator mediator) : ControllerBase
{
    private const int StatusErrorCode = 503;

    [HttpPost(Name = nameof(CreateIssue))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> CreateIssue([FromBody] IssueDto request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var command = new CreateIssueCommand(
            request.Name, 
            request.Description, 
            request.ApiClient);

        var result = await mediator.Send(command, cancellationToken);

        if (result)
            return NoContent();
        else
            return StatusCode(StatusErrorCode, GetErrorMessage(request.ApiClient));
    }

    [HttpPatch("{issueId:int}", Name = nameof(EditIssue))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> EditIssue([FromRoute] int issueId, [FromBody] IssueDto request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var command = new EditIssueCommand(
            issueId, 
            request.Name, 
            request.Description,
            request.ApiClient);

        var result = await mediator.Send(command, cancellationToken);

        if (result)
            return NoContent();
        else
            return StatusCode(StatusErrorCode, GetErrorMessage(request.ApiClient));
    }

    [HttpPatch("{issueId:int}/status", Name = nameof(CloseIssue))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> CloseIssue([FromRoute] int issueId, [FromBody] IssueApiDto request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var command = new CloseIssueCommand(
            issueId, 
            request.ApiClient);

        var result = await mediator.Send(command, cancellationToken);

        if (result)
            return NoContent();
        else
            return StatusCode(StatusErrorCode, GetErrorMessage(request.ApiClient));
    }

    private static string GetErrorMessage(ApiClient apiClient)
    {
        return $"Service: {apiClient} Unavailable";
    }
}