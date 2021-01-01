using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Services.GenericService
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;

        protected GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public IQueryable<TEntity> GetAllAsQuerable()
        {
            return _repository.GetAllAsQuerable();
        }

        public Task<List<TEntity>> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity Create(TEntity entity)
        {
            return _repository.Create(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            return _repository.Delete(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity FindByIds(params object[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByIdsAsync(params object[] ids)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(object id)
        {
            return _repository.FindById(id);
        }

        public Task<TEntity> FindByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _repository.Save();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}