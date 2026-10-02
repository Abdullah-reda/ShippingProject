using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.DbContext;
using DAL.Contracts;
using Domains;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DAL.Exceptions;

namespace DAL.Repositories
{
    public class TableRepository<T> : ITableRepository<T> where T : BaseTable
    {
        private readonly ShippingContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger<TableRepository<T>> _logger;
        public TableRepository(ShippingContext context, ILogger<TableRepository<T>> logger)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _logger = logger;
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
            }
        }

        public T? GetById(Guid id)
        {
            try
            {
                return _dbSet.Where(a => a.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
                
            }
        }

        public bool Add(T entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                _dbSet.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);

            }
        }

        public bool Update(T entity)
        {
            try
            {
                var dbDate = GetById(entity.Id);
                entity.CreatedDate = dbDate.CreatedDate;
                entity.CreatedBy = dbDate.CreatedBy;
                dbDate.UpdatedDate = DateTime.Now;

                _dbSet.Update(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
   
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var entity = GetById(id);
                if (entity == null)
                    return false;

                _dbSet.Remove(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);

            }
        }
        public bool ChangeStatus(Guid id, int status = 1)
        {
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    entity.CurrentState = status;
                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex, "", _logger);
 
            }
        }
    }
}
