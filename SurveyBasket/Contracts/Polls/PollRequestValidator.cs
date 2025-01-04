namespace SurveyBasket.Contracts.Polls;

public class PollRequestValidator : AbstractValidator<PollRequest>
{
    public PollRequestValidator()
    {
        RuleFor((pollRequest) => pollRequest.Title)
            .NotEmpty()
            .Length(3, 100);

        RuleFor((pollRequest) => pollRequest.Summary)
            .NotEmpty()
            .Length(3, 1500);

        RuleFor((pollRequest) => pollRequest.StartsAt)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));

        RuleFor((pollRequest) => pollRequest.EndsAt)
          .NotEmpty();

        RuleFor((pollRequest) => pollRequest)
            .Must(HasValidDates)
            .WithName(nameof(PollRequest.EndsAt))
            .WithMessage("{PropertyName} must be greater than or equals start date");
    }

    private bool HasValidDates(PollRequest pollRequest)
    {
        return pollRequest.EndsAt >= pollRequest.StartsAt;
    }
}
