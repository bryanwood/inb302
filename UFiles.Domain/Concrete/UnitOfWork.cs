using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Abstract;
using System.Data.Entity;

namespace UFiles.Domain.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            Context = new UFileContext();
        }

        public DbContext Context{ get; set; }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public bool LazyLoadingEnabled
        {
            get { return Context.Configuration.LazyLoadingEnabled; }
            set { Context.Configuration.LazyLoadingEnabled = value; }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
