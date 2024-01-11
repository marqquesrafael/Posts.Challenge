using Posts.Challenge.Domain.Configuration.Jwt;
using Posts.Challenge.Domain.Entities.User;
using Posts.Challenge.Domain.Interfaces.Services.Jwt;
using Posts.Challenge.Domain.Responses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Posts.Challenge.Application.Services.Jwt
{
    public class JwtProviderService : IJwtProviderService
    {
        private readonly JWTConfiguration _jwtConfiguration;

        public JwtProviderService(IOptions<JWTConfiguration> options)
        {
            _jwtConfiguration = options.Value;
        }

        public TokenResponse Generate(UserEntity user)
        {
            var claims = new Claim[] { new("Email", user.Email) };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtConfiguration.Secret)), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _jwtConfiguration.EmitedBy,
                _jwtConfiguration.ValidatedIn,
                claims,
                null,
                DateTime.UtcNow.AddHours(_jwtConfiguration.ExpirationInHour),
                signingCredentials
                );

            var tokenValue = new TokenResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpireIn = _jwtConfiguration.ExpirationInHour
            };

            return tokenValue;
        }
    }
}
