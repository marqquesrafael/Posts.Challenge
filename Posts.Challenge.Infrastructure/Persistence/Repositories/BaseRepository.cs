using Posts.Challenge.Domain.Entities;
using Posts.Challenge.Domain.Interfaces.Repositories;
using Posts.Challenge.Infrastructure.Persistence.Configuration;

namespace Posts.Challenge.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected PostsDbContext _PostsDbContext;

        public BaseRepository(PostsDbContext PostsDbContext)
        {
            _PostsDbContext = PostsDbContext;
        }

        public void Insert(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;

            _PostsDbContext.Add(entity);
            _PostsDbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _PostsDbContext.Set<TEntity>().Remove(entity);
            _PostsDbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;

            _PostsDbContext.Set<TEntity>().Update(entity);
            _PostsDbContext.SaveChanges();
        }

        public IQueryable<TEntity> Select() => _PostsDbContext.Set<TEntity>();

        public TEntity GetById(long id) => _PostsDbContext.Set<TEntity>().Find(id);

        public void RemoveSoftly(TEntity entity)
        {
            entity.Active = false;
            Update(entity);
        }
    }
}
