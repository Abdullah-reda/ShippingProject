using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BL;
using DAL.DbContext;

namespace DAL
{
    public class GenericRepository<T> : IGenericRepository<T>
    where T : class
    {
        private readonly ShippingContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ShippingContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception ex)
            {
                // Log exception
                throw;
            }
        }

        public T? GetById(int id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw;
            }
        }

        public bool Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }
        }
    }
}
