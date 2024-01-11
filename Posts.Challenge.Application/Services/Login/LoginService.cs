using Posts.Challenge.Domain.Exceptions;
using Posts.Challenge.Domain.Interfaces.Services.Jwt;
using Posts.Challenge.Domain.Interfaces.Services.Login;
using Posts.Challenge.Domain.Interfaces.Services.User;
using Posts.Challenge.Domain.Responses;

namespace Posts.Challenge.Application.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IJwtProviderService _jwtProviderService;
        private readonly IUserService _userService;

        public LoginService(IJwtProviderService jwtProviderService, IUserService userService)
        {
            _jwtProviderService = jwtProviderService;
            _userService = userService;
        }

        public TokenResponse Authenticate(string email, string password)
        {
            var user = _userService.GetUserByEmailAndPassword(email, password);

            if (user is null)
                throw new InvalidCredentialsException();

            TokenResponse token = _jwtProviderService.Generate(user);

            return token;
        }

    }
}
