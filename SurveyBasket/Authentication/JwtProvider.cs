﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SurveyBasket.Authentication;

public class JwtProvider : IJwtProvider
{
    public (string token, int expiresIn) GenerateToken(ApplicationUser user)
    {
        Claim[] claims = [
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        ];

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yTj0HMEyTQWsgpBKFJevGKOFVl2t72tX"));

        var singingCreadentionals = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var expiresIn = 30;

        var expirationDate = DateTime.UtcNow.AddMinutes(expiresIn);

        var token = new JwtSecurityToken(
            issuer: "SurveyBasketApp",
            audience: "SurveyBasketApp users",
            claims: claims,
            expires: expirationDate,
            signingCredentials: singingCreadentionals
       );


        return (token: new JwtSecurityTokenHandler().WriteToken(token), expiresIn: expiresIn * 60);
    }
}
