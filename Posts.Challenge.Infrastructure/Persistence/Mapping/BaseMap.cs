using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Posts.Challenge.Domain.Entities;

namespace Posts.Challenge.Infrastructure.Persistence.Mapping
{
    public abstract class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public abstract string GetTableName();

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(GetTableName());

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
            builder.Property(p => p.Active).HasColumnName("active");

        }
    }
}
