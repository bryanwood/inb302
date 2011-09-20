using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void Save(User user);
        void Delete(User user);
    }
}
