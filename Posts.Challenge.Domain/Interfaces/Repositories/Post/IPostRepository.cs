using Posts.Challenge.Domain.Entities.Post;

namespace Posts.Challenge.Domain.Interfaces.Repositories.Post
{
    public interface IPostRepository : IBaseRepository<PostEntity>
    {
        PostEntity FindByUser(long userId);
    }
}
