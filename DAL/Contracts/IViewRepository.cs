using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contracts
{
    public interface IViewRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(Guid id);

    }
}
