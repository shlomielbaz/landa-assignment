using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LA.Domain
{
    public interface IRepository
    {
        public T Get<T>(Expression<Func<T, bool>> predicate) where T : IEntity;
        public IQueryable<T> GetList<T>(Expression<Func<T, bool>> predicate) where T : IEntity;
        public IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy) where T : IEntity;
        public IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate, OrderByType orderByType, Expression<Func<T, TKey>> orderBy) where T : IEntity;
        public IQueryable<T> GetList<T, TKey>(Expression<Func<T, TKey>> orderBy) where T : IEntity;
        public IQueryable<T> GetList<T, TKey>(OrderByType orderByType, Expression<Func<T, TKey>> orderBy) where T : IEntity;
        public IQueryable<T> GetList<T>() where T : IEntity;
        public void Add<T>(T entity) where T : IEntity;
        public void Update<T>(T entity, T entityFromDb) where T : IEntity;
        public void Delete<T>(T entity) where T : IEntity;
        public int Count<T>(Expression<Func<T, bool>> predicate) where T : IEntity;
        public OperationStatus Save(string message = null);
    }
}
