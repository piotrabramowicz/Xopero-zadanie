using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xopero.Library.Clients;
using Xopero.Library.Commands;
using Xopero.Library.Enums;
using Xopero.Library.Handlers;

namespace Xopero.IntegrationTest.Handlers;

public class CloseIssueCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCloseIssue_WhenValidRequest()
    {
        // Arrange
        var apiClientMock = Substitute.For<IApiClient>();
        apiClientMock
            .CloseIssue(Arg.Any<int>())
            .Returns(Task.FromResult(true));

        var services = new ServiceCollection();
        services.AddKeyedSingleton<IApiClient>(ApiClient.GitHub.ToString(), apiClientMock);
        var serviceProvider = services.BuildServiceProvider();

        var handler = new CloseIssueCommandHandler(serviceProvider);
        var command = new CloseIssueCommand(123, ApiClient.GitHub);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeTrue();
    }
}