namespace SurveyBasket.Authentication;

public interface IJwtProvider
{
    //Tuples, it return two values
    (string token, int expiresIn) GenerateToken(ApplicationUser user);
}
