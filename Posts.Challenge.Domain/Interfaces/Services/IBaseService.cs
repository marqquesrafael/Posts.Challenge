using Posts.Challenge.Domain.Entities;

namespace Posts.Challenge.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        bool Create(TEntity entity);

        void Delete(long id);

        bool Update(TEntity entity);

        IQueryable<TEntity> GetAll();

        TEntity GetById(long id);

        bool RemoveSoftly(long id);
    }
}
