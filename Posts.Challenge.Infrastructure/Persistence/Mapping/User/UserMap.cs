using Posts.Challenge.Domain.Entities.User;
using Posts.Challenge.Domain.Enums.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Posts.Challenge.Infrastructure.Persistence.Mapping.User
{
    public class UserMap : BaseMap<UserEntity>
    {
        public override string GetTableName() => "tb_user";

        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.FullName)
                .HasColumnName("full_name")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(p => p.Password)
                .HasColumnName("password")
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasColumnName("phone_number")
                .IsRequired();

            builder.Property(p => p.Type)
                .HasColumnName("type")
                .HasConversion<string>()
                .IsRequired();


            builder.HasData(
                new UserEntity("system@posts.com", "1234", "Administrator", "31 99999-9999", UserTypeEnum.System) { Id = 1, CreatedAt = DateTime.Now },
                new UserEntity("admin@posts.com", "1234", "Administrator", "31 99999-9999", UserTypeEnum.Administrator) { Id = 2, CreatedAt = DateTime.Now }
                );
        }
    }
}
