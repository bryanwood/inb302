using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Abstract;
using System.Data.Entity;
using System.Linq.Expressions;

namespace UFiles.Domain.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; set; }

        private DbContext _context;

        private DbContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = UnitOfWork.Context;
                }
                return _context;
            }
        }

        public virtual IQueryable<T> All()
        {
            return Context.Set<T>().AsQueryable();
        }
        public virtual IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            Context.Entry(entity).State = System.Data.EntityState.Modified;
        }
        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }
}
