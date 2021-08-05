using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LA.Domain;

namespace LA.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly ILayoutRepository _db;

        public void Add(LayoutViewModel entity)
        {
            _db.Add(new Layout()
            {
                Content = entity.Content
            });
        }

        public void Delete(LayoutViewModel entity)
        {
            throw new NotImplementedException();
        }

        public LayoutViewModel Get(Expression<Func<LayoutViewModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LayoutViewModel> GetAll()
        {
            return _db.GetList<Layout>();
        }

        public void Update(LayoutViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
