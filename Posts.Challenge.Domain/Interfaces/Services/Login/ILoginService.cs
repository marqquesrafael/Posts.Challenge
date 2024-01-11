using Posts.Challenge.Domain.Responses;

namespace Posts.Challenge.Domain.Interfaces.Services.Login
{
    public interface ILoginService
    {
        TokenResponse Authenticate(string email, string password);
    }
}
