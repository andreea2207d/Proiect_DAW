﻿using DAWProject.Models;
using DAWProject.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAWProject.Services.GenericService
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAllAsQuerable();
        Task<List<TEntity>> GetAll();

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(TEntity entity);

        void CreateRange(IEnumerable<TEntity> entities);

        void UpdateRange(IEnumerable<TEntity> entities);
        void DeleteRange(IEnumerable<TEntity> entities);

        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        TEntity FindByIds(params object[] ids);
        Task<TEntity> FindByIdsAsync(params object[] ids);

        TEntity FindById(object id);

        Task<TEntity> FindByIdAsync(object id);
        bool Save();
        Task<bool> SaveAsync();
    }
}
