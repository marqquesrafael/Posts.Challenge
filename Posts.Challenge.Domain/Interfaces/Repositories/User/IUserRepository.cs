using Posts.Challenge.Domain.Entities.User;

namespace Posts.Challenge.Domain.Interfaces.Repositories.User
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        UserEntity GetUserByEmailAndPassword(string email, string password);
    }
}
