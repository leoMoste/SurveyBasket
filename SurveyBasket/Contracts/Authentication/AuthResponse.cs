namespace SurveyBasket.Contracts.Authentication;

public record AuthResponse(
    string Id,
    string? Email,
    string FirstName,
    string LasttName,
    string Token,
    int ExpiresIn
);

