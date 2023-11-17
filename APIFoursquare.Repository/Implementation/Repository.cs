using APIFoursquare.Repository.Context;
using APIFoursquare.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIFoursquare.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApiFoursquareDbContext _context;

        public Repository(ApiFoursquareDbContext context) => _context = context;

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            using IDbContextTransaction dbTrans = _context.Database.BeginTransaction();
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();

                dbTrans.Commit();

                return true;
            }
            catch (Exception)
            {
                dbTrans.Rollback();

                throw;
            }
        }

        public Task<T?> GetAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>>? orderBy = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<TType?> GetAsync<TType>(Expression<Func<T, bool>> condition, Expression<Func<T, TType>> selection) where TType : class
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetListAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<List<T>> GetListAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>>? orderBy = null, bool descending = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<TType>> GetListAsync<TType>(Expression<Func<T, bool>> condition, Expression<Func<T, TType>> selection) where TType : class
        {
            throw new NotImplementedException();
        }

        public Task<List<TType>> GetListAsync<TType>(Expression<Func<T, TType>> selection) where TType : class
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetPagedReponseAsync(Expression<Func<T, bool>> condition, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TType>> GetPagedReponseAsync<TType>(Expression<Func<T, bool>> condition, Expression<Func<T, TType>> selection, int pageNumber, int pageSize) where TType : class
        {
            throw new NotImplementedException();
        }

        public async Task<T> InsertAsync(T entity)
        {
            using IDbContextTransaction dbTrans = _context.Database.BeginTransaction();
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();

                dbTrans.Commit();

                return entity;
            }
            catch (Exception)
            {
                dbTrans.Rollback();

                throw;
            }
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
