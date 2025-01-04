namespace SurveyBasket.Contracts.Polls;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor((loginRequest) => loginRequest.Email)
            .EmailAddress()
            .NotEmpty();

        RuleFor((loginRequest) => loginRequest.Password)
            .NotEmpty();

    }
}
