using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xopero.API.Controllers.Issues.Models;
using Xopero.Library.Commands;

namespace Xopero.API.Controllers.Issues;

[ApiController]
[Route("[controller]")]
public class IssuesController(IMediator mediator) : ControllerBase
{

    [HttpPost(Name = nameof(CreateIssue))]
    public async Task<IActionResult> CreateIssue([FromBody] CreateIssueDto request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var command = new CreateIssueCommand(
            request.Name, 
            request.Description, 
            request.ApiClient); //mapper.Map<CreateBaseCustomerCommand>(request);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpPut(Name = nameof(EditIssue))]
    public async Task<IActionResult> EditIssue([FromBody] EditIssueDto request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var command = new EditIssueCommand(
            request.Id, 
            request.Name, 
            request.Description,
            request.ApiClient); //mapper.Map<CreateBaseCustomerCommand>(request);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }


    [HttpPatch(Name = nameof(CloseIssue))]
    public async Task<IActionResult> CloseIssue([FromBody] CloseIssue request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var command = new CloseIssueCommand(request.Id); //mapper.Map<CreateBaseCustomerCommand>(request);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }
}