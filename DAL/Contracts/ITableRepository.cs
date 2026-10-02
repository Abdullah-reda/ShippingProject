using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contracts
{
    public interface ITableRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(Guid id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(Guid id);
        bool ChangeStatus(Guid id, int status = 1);
    }
}
