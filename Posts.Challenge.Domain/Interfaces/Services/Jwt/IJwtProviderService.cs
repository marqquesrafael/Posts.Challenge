using Posts.Challenge.Domain.Entities.User;
using Posts.Challenge.Domain.Responses;

namespace Posts.Challenge.Domain.Interfaces.Services.Jwt
{
    public interface IJwtProviderService
    {
        TokenResponse Generate(UserEntity user);
    }
}
