using Posts.Challenge.Domain.Entities.User;
using Posts.Challenge.Domain.Requests;

namespace Posts.Challenge.Domain.Interfaces.Services.User
{
    public interface IUserService : IBaseService<UserEntity>
    {
        UserEntity FindUserByEmail(string email);

        UserEntity GetUserByEmailAndPassword(string email, string password);

        TOut GetById<TOut>(long id);

        Task Register(UserRegisterRequest request);
    }
}
