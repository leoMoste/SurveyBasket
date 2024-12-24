namespace SurveyBasket.Contracts.Validations;

public class CreatePollRequestValidator:AbstractValidator<CreatePollRequest>
{
    public CreatePollRequestValidator()
    {
        RuleFor((pollRequest) => pollRequest.Title)
            .NotEmpty()
            .Length(3, 100);

        RuleFor((pollRequest) => pollRequest.Description)
            .NotEmpty()
            .Length(3, 1000);
    }
}
