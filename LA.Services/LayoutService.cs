using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LA.Domain;

namespace LA.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly ILayoutRepository _db;

        #region CTORS
        public LayoutService(ILayoutRepository repository)
        {
            _db = repository;
        }
        #endregion

        public void Add(LayoutViewModel entity)
        {
            IQueryable<Layout> query = _db.GetList<Layout>();

            query = query.Where(x => x.Default == true);
            query.ToList().ForEach(x => x.Default = false);

            _db.Save();


            _db.Add(new Layout()
            {
                Content = entity.Content,
                Default = true
            });

            _db.Save();
        }

        public void Delete(LayoutViewModel entity)
        {
            throw new NotImplementedException();
        }

        public LayoutViewModel Get(Expression<Func<LayoutViewModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public LayoutViewModel GetDefault()
        {
           
           Layout item = _db.Get<Layout>(x=>x.Default == true);

            if (item != null)
            {
                return new LayoutViewModel()
                {
                    Content = item.Content
                };
            }
            return null;
        }

        public IEnumerable<LayoutViewModel> GetAll()
        {
            IList<LayoutViewModel> list = new List<LayoutViewModel>();
            foreach (Layout item in _db.GetList<Layout>())
            {
                list.Add(new LayoutViewModel()
                {
                    Content = item.Content,
                    Default = item.Default
                });
            }
            return list;
        } 

        public void Update(LayoutViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
