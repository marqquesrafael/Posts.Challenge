using Posts.Challenge.Domain.Entities;
using Posts.Challenge.Domain.Exceptions;
using Posts.Challenge.Domain.Interfaces.Repositories;
using Posts.Challenge.Domain.Interfaces.Services;

namespace Posts.Challenge.Application.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public IQueryable<TEntity> GetAll()
        {
            var entities = _repository.Select();
            return entities;
        }

        public bool Create(TEntity entity)
        {
            try
            {
                if (entity.Id != 0)
                    throw new InsertEntityWithIdException();

                _repository.Insert(entity);
                return true;
            }
            catch (InsertEntityWithIdException ex)
            {
                throw ex;
            }
            catch
            {
                return false;
            }
        }

        public void Delete(long id)
        {
            var entity = GetById(id);

            if (entity is null)
                throw new EntityNotFoundException();

            _repository.Delete(entity);
        } 

        public TEntity GetById(long id)
        {
            var entity = _repository.GetById(id);
            return entity;
        }

        public bool RemoveSoftly(long id)
        {
            try
            {
                var entity = GetById(id);

                if (entity is null)
                    throw new EntityNotFoundException();

                _repository.RemoveSoftly(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                if (entity.Id == 0)
                    return false;

                _repository.Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
