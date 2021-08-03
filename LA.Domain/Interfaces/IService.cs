using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LA.Domain
{
    public interface IService<T> where T : class, new()
    {
        IEnumerable<T> GetAll();

        T Get(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
