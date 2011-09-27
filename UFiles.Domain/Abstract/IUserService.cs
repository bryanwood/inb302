using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    
    public interface IUserService
    {
        User GetUserByEmail(string email);
        User GetUserById(int id);
        void DeleteUser(int id);
        IQueryable<User> GetAllUsers();
        void SaveUser(User user);
        bool ChangePassword(string email, string newPassword);
        User CreateUser(User user);
    }
}
