using Posts.Challenge.Domain.Entities.User;
using Posts.Challenge.Domain.Interfaces.Repositories.User;
using Posts.Challenge.Infrastructure.Persistence.Configuration;

namespace Posts.Challenge.Infrastructure.Persistence.Repositories.User
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(PostsDbContext toroInvestimentosDbContext) : base(toroInvestimentosDbContext) { }

        public UserEntity GetUserByEmailAndPassword(string email, string password)
        {
            var user = Select()
                .Where(p =>
                       p.Email == email &&
                       p.Password == password &&
                       p.Active)
                .FirstOrDefault();

            return user;
        }

    }
}
