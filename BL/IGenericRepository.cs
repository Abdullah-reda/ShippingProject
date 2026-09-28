using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
