using Posts.Challenge.Domain.Entities.Post;
using Posts.Challenge.Domain.Interfaces.Repositories.Post;
using Posts.Challenge.Infrastructure.Persistence.Configuration;

namespace Posts.Challenge.Infrastructure.Persistence.Repositories.Post
{
    public class PostRepository : BaseRepository<PostEntity>, IPostRepository
    {
        public PostRepository(PostsDbContext PostsDbContext) : base(PostsDbContext)
        {
        }

        public PostEntity FindByUser(long userId)
        {
            var entity = Select()
                .Where(p => 
                    p.UserId == userId &&
                    p.Active)
                .FirstOrDefault();
            return entity;
        }
    }
}
