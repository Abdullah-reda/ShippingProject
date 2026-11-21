using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Contracts
{
    public interface IViewRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(Guid id);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        List<T> GetList(Expression<Func<T, bool>> filter);

    }
}
