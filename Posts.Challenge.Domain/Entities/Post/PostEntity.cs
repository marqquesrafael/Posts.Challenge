using Posts.Challenge.Domain.Entities.User;

namespace Posts.Challenge.Domain.Entities.Post
{
    public class PostEntity : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public long UserId { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
