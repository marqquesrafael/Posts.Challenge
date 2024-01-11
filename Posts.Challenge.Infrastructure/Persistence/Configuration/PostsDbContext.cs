using Microsoft.EntityFrameworkCore;
using Posts.Challenge.Infrastructure.Persistence.Mapping.Post;
using Posts.Challenge.Infrastructure.Persistence.Mapping.User;

namespace Posts.Challenge.Infrastructure.Persistence.Configuration
{
    public class PostsDbContext : DbContext
    {
        public PostsDbContext(DbContextOptions<PostsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
