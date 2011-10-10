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
        
        public Repository(UFileContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork { get; set; }

        private DbContext context;

        public virtual IQueryable<T> All()
        {
            return context.Set<T>().AsQueryable();
        }
        public virtual IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            context.Entry(entity).State = System.Data.EntityState.Modified;
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }
    }
}
