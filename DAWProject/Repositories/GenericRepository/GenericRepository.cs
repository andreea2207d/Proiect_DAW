﻿using DAWProject.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWProject.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DawAppContext _context;
        protected readonly DbSet<TEntity> _table;
        public GenericRepository(DawAppContext dbContext)
        {
            _context = dbContext;
            _table = _context.Set<TEntity>();
        }

        public  async Task<List<TEntity>> GetAll()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public IQueryable<TEntity> GetAllAsQuerable()
        {
            return _table.AsNoTracking();
        }

        public TEntity Create(TEntity entity)
        {
            return _table.Add(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return _table.Update(entity).Entity;
        }

        public TEntity Delete(TEntity entity)
        {
            return _table.Remove(entity).Entity;
        }
        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);

        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);

        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        public TEntity FindById(object id)
        {
            return _table.Find(id);
        }

        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        public TEntity FindByIds(params object[] ids)
        {
            return _table.Find(ids[0], ids[1]);
        }
        public async Task<TEntity> FindByIdsAsync(params object[] ids)
        {
            return await _table.FindAsync(ids[0], ids[1]);
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (SqlException)
            {
                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();

                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                                         "Message: " + ex.Errors[i].Message + "\n" +
                                         "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                                         "Source: " + ex.Errors[i].Source + "\n" +
                                         "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
            }
            return false;
        }
    }
}
