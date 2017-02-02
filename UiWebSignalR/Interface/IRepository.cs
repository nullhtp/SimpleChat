using System;
using System.Collections.Generic;

namespace Domain.Interface
{
    public interface IRepository <T>
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        bool Add(T item);
        bool Update(T item);
        bool Delete(Guid id);
    }
}