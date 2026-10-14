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
                return _dbSet.Where(x => x.CurrentState > 0).ToList();
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
                entity.CurrentState = 1;
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
                var dbEntity = GetById(entity.Id);

                if (dbEntity == null)
                    return false;

                var createdDate = dbEntity.CreatedDate;
                var createdBy = dbEntity.CreatedBy;

                _context.Entry(dbEntity).CurrentValues.SetValues(entity);

                dbEntity.CreatedDate = createdDate;
                dbEntity.CreatedBy = createdBy;
                dbEntity.UpdatedDate = DateTime.Now;

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
        public bool ChangeStatus(Guid Id, int status)
        {
            try
            {
                var entity = GetById(Id);
                if (entity != null)
                {
                    entity.CurrentState = 0;
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
