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

        public async Task<int> CountAsync()
        {
            try
            {
                return await _context.Set<T>().CountAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> condition)
        {
            try
            {
                return await _context.Set<T>().Where(condition).CountAsync();
            }
            catch (Exception)
            {
                throw;
            }
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

        public async Task<T?> GetAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>>? orderBy = null, bool descending = false)
        {
            try
            {
                var query = _context.Set<T>().Where(condition);

                if (orderBy != null)
                {
                    query = descending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
                }

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TType?> GetAsync<TType>(Expression<Func<T, bool>> condition, Expression<Func<T, TType>> selection) where TType : class
        {
            try
            {
                return await _context.Set<T>().Where(condition).Select(selection).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
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

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> condition, Expression<Func<T, object>>? orderBy = null, bool descending = false)
        {
            try
            {
                var query = _context.Set<T>().Where(condition);

                if (orderBy != null)
                {
                    query = descending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TType>> GetListAsync<TType>(Expression<Func<T, bool>> condition, Expression<Func<T, TType>> selection) where TType : class
        {
            try
            {
                return await _context.Set<T>().Where(condition).Select(selection).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TType>> GetListAsync<TType>(Expression<Func<T, TType>> selection) where TType : class
        {
            try
            {
                return await _context.Set<T>().Select(selection).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            try
            {
                return await _context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> GetPagedReponseAsync(Expression<Func<T, bool>> condition, int pageNumber, int pageSize)
        {
            try
            {
                return await _context.Set<T>().Where(condition).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<TType>> GetPagedReponseAsync<TType>(Expression<Func<T, bool>> condition, Expression<Func<T, TType>> selection, int pageNumber, int pageSize) where TType : class
        {
            try
            {
                return await _context.Set<T>().Where(condition).Select(selection).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
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

        public async Task<bool> UpdateAsync(T entity)
        {
            using IDbContextTransaction dbTrans = _context.Database.BeginTransaction();
            try
            {
                _context.Set<T>().Update(entity);
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
    }
}
