
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


using LA.Domain;

namespace LA.Data
{
	public class Repository<C> : IDisposable, IRepository
	   where C : DbContext, new()
	{
		private C dataContext;

		private static readonly object addEntityObject = new object();

		public virtual C DataContext
		{
			get
			{
				if (dataContext == null)
				{
					dataContext = new C();
				}

				return dataContext;
			}
		}

		public virtual T Get<T>(Expression<Func<T, bool>> predicate) where T : IEntity
        {
			return DataContext.Set<T>().Where(predicate).SingleOrDefault();
		}

		public virtual IQueryable<T> GetList<T>(Expression<Func<T, bool>> predicate) where T : IEntity
		{
			return DataContext.Set<T>().Where(predicate);
		}

		public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy)
            where T : IEntity
		{
            return GetList(predicate, OrderByType.Ascending, orderBy);
        }

        public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate,
            OrderByType orderByType, Expression<Func<T, TKey>> orderBy)
            where T : IEntity
		{
            if (orderByType == OrderByType.Ascending)
            {
                return GetList(predicate).OrderBy(orderBy);
            }
            else
            {
                return GetList(predicate).OrderByDescending(orderBy);
            }
        }

        public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, TKey>> orderBy)
            where T : IEntity
		{
            return GetList<T, TKey>(OrderByType.Ascending, orderBy);
        }

        public virtual IQueryable<T> GetList<T, TKey>(OrderByType orderByType, Expression<Func<T, TKey>> orderBy)
            where T : IEntity
		{
            if (orderByType == OrderByType.Ascending)
            {
                return GetList<T>().OrderBy(orderBy);
            }
            else
            {
                return GetList<T>().OrderBy(orderBy);
            }
        }

        public virtual IQueryable<T> GetList<T>()
            where T : IEntity
		{
            return DataContext.Set<T>();
        }

		public void Add<T>(T entity) where T : IEntity
        {
			DataContext.Set<T>().Add(entity);
		}

        public void Update<T>(T entity, T entityFromDb) where T : IEntity
        {
            var entry = DataContext.Entry<T>(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = DataContext.Set<T>();
                T attachedEntity = set.Find(entity.ID);

                if (attachedEntity != null)
                {
                    var attachedEntry = DataContext.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }

		public void Delete<T>(T entity) where T : IEntity
        {
			DataContext.Set<T>().Remove(entity);
		}

        public int Count<T>(Expression<Func<T, bool>> predicate) where T : IEntity
        {
			return DataContext.Set<T>().Count(predicate);
		}

        public OperationStatus Save(string message = null)
        {
            DataContext.SaveChanges();

            return new OperationStatus
            {
                Message = message,
                Status = true,
            };
        }

		public void Dispose()
		{
			if (DataContext != null)
			{
				DataContext.Dispose();
			}
		}
    }
}


		

		//public virtual void Add<T>(T entity)
		//	where T : class
		//{
		//	
		//}

		//public virtual bool Any<T>(Expression<Func<T, bool>> predicate)
		//	where T : class
		//{
		//	return DataContext.Set<T>().Any(predicate);
		//}

		//public virtual int Count<T>(Expression<Func<T, bool>> predicate)
		//	where T : class
		//{
		//	
		//}

		//public virtual T Get<T>(Expression<Func<T, bool>> predicate)
		//	where T : class
		//{
		//	return DataContext.Set<T>().Where(predicate).SingleOrDefault();
		//}

		//public virtual IQueryable<T> GetList<T>(Expression<Func<T, bool>> predicate)
		//	where T : class
		//{
		//	return DataContext.Set<T>().Where(predicate);
		//}

		

		//public virtual void Update<T>(T entity) where T : IEntity
		//{
		
		//}

		//public virtual void Delete<T>(T entity)
		//	where T : class
		//{
		//	DataContext.Set<T>().Remove(entity);
		//}

		//public async Task DeleteAsync<T>(T entity)
		//	where T : class
		//{
		//	await Task.Run(() => Delete<T>(entity));
		//}

		//public virtual void DeleteAll<T>(ICollection<T> collection)
		//	where T : class
		//{
		//	DbSet<T> dbSet = DataContext.Set<T>();
		//	collection.ToList<T>().ForEach(x => dbSet.Remove(x));
		//}

		//public virtual OperationStatus Save(string message = null)
		//{
	
		//}