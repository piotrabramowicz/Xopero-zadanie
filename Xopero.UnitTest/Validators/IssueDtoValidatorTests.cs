using FluentValidation.TestHelper;
using Xopero.API.Controllers.Issues.Models;
using Xopero.API.Controllers.Issues.Validators;
using Xopero.Library.Enums;

namespace Xopero.UnitTest.Validators;

public class IssueDtoValidatorTests
{
    private readonly IssueDtoValidator _validator = new();

    private static readonly IssueDto InvalidIssueDto = new()
    {
        ApiClient = ApiClient.GitHub,
        Name = null,
        Description = null
    };

    [Fact]
    public void ApiClient_ShouldHaveValidationError_WhenInvalidEnum()
    {
        var invalidDto = InvalidIssueDto with { ApiClient = (ApiClient)999 };
        _validator.TestValidate(invalidDto).ShouldHaveValidationErrorFor(x => x.ApiClient);
    }

    [Fact]
    public void GitHub_Name_ShouldHaveValidationErrors()
    {
        var dto = InvalidIssueDto with { ApiClient = ApiClient.GitHub, Name = "" };
        _validator.TestValidate(dto).ShouldHaveValidationErrorFor(x => x.Name);

        dto = dto with { Name = new string('a', 21) };
        _validator.TestValidate(dto).ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void GitHub_Description_ShouldHaveValidationErrors_WhenTooLong()
    {
        var dto = InvalidIssueDto with { ApiClient = ApiClient.GitHub, Description = new string('a', 101) };
        _validator.TestValidate(dto).ShouldHaveValidationErrorFor(x => x.Description);
    }

    [Fact]
    public void GitLab_Name_ShouldHaveValidationErrors()
    {
        var dto = InvalidIssueDto with { ApiClient = ApiClient.GitLab, Name = "" };
        _validator.TestValidate(dto).ShouldHaveValidationErrorFor(x => x.Name);

        dto = dto with { Name = "invalid" };
        _validator.TestValidate(dto).ShouldHaveValidationErrorFor(x => x.Name);

        dto = dto with { Name = "GL-Short" };
        _validator.TestValidate(dto).ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void GitLab_Description_ShouldHaveValidationErrors()
    {
        var dto = InvalidIssueDto with { ApiClient = ApiClient.GitLab, Description = "" };
        _validator.TestValidate(dto).ShouldHaveValidationErrorFor(x => x.Description);

        dto = dto with { Description = "InvalidDescription" };
        _validator.TestValidate(dto).ShouldHaveValidationErrorFor(x => x.Description);

        dto = dto with { Description = "GL-" + new string('a', 48) };
        _validator.TestValidate(dto).ShouldHaveValidationErrorFor(x => x.Description);
    }

    [Fact]
    public void GitHub_ShouldPassValidation_WhenValidData()
    {
        var dto = new IssueDto
        {
            ApiClient = ApiClient.GitHub,
            Name = "ValidName",
            Description = "Valid description"
        };

        _validator.TestValidate(dto).ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void GitLab_ShouldPassValidation_WhenValidData()
    {
        var dto = new IssueDto
        {
            ApiClient = ApiClient.GitLab,
            Name = "GL-1234567",
            Description = "GL-ValidDescription"
        };

        _validator.TestValidate(dto).ShouldNotHaveAnyValidationErrors();
    }

}
