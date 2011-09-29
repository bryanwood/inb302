using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace UFiles.Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; set; }

        void Commit();

        bool LazyLoadingEnabled { get; set; }
    }
}
