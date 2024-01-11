using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posts.Challenge.Domain.Entities.Post;
using Posts.Challenge.Domain.Entities.User;

namespace Posts.Challenge.Infrastructure.Persistence.Mapping.Post
{
    public class PostMap : BaseMap<PostEntity>
    {
        public override string GetTableName() => "tb_post";

        public override void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Title)
                .HasColumnName("title")
                .IsRequired();

            builder.Property(p => p.Content)
                .HasColumnName("content")
                .IsRequired();

            builder.Property(p => p.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);
        }
    }
}
