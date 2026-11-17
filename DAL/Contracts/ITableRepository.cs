using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        List<T> GetList(Expression<Func<T, bool>> filter);
    }
}
