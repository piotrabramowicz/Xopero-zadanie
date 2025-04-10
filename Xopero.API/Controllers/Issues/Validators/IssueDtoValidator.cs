using FluentValidation;
using Xopero.API.Controllers.Issues.Models;
using Xopero.Library.Enums;

namespace Xopero.API.Controllers.Issues.Validators;

public class IssueDtoValidator : AbstractValidator<IssueDto>
{
    public IssueDtoValidator()
    {
        RuleFor(x => x.ApiClient)
            .IsInEnum().WithMessage("Invalid API client selected.");

        When(x => x.ApiClient == ApiClient.GitHub, () =>
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required for GitHub.")
                .MaximumLength(20).WithMessage("Name cannot exceed 20 characters for GitHub.");

            RuleFor(x => x.Description)
                .MaximumLength(100).WithMessage("Description cannot exceed 100 characters for GitHub.");
        });

        When(x => x.ApiClient == ApiClient.GitLab, () =>
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required for GitLab.")
                .Matches("^GL-.*").WithMessage("Name must start with 'GL-' for GitLab.")
                .Length(10).WithMessage("Name must be exactly 10 characters for GitLab.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required for GitLab.")
                .Matches("^GL-.*").WithMessage("Description must start with 'GL-' for GitLab.")
                .MaximumLength(50).WithMessage("Description cannot exceed 50 characters for GitLab.");
        });
    }
}