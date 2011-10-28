using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Concrete
{
    public class UserService : IUserService
    {
        private UFileContext db;
        private IEmailService emailService;

        public UserService(UFileContext context, IEmailService emailService)
        {
            db = context;
            this.emailService = emailService;
        }

        public Entities.User GetUserByEmail(string email)
        {
            return db.Users.Where(u => u.Email == email).Single();
        }

        public Entities.User GetUserById(int id)
        {
            return db.Users.Where(u => u.UserId == id).Single();
        }

        public void DeleteUser(int id)
        {

            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
      
           
        }

        public IQueryable<Entities.User> GetAllUsers()
        {
            return db.Users;
        }

        public void SaveUser(Entities.User user)
        {
                if (user.UserId == 0)
                {
                    db.Users.Add(user);
                }
                else
                {
                    db.Entry(user).State = System.Data.EntityState.Modified;
                }
                db.SaveChanges();
        }

        public bool ChangePassword(string email, string newPassword)
        {
            try
            {
                var user = db.Users.Where(u => u.Email == email).Single();
                user.PasswordHash = newPassword;
                db.Entry(user).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User CreateUser(Entities.User user)
        {
                db.Users.Add(user);

                db.SaveChanges();
                
                emailService.SendEmail(new string[]{user.Email},string.Format("Hi you're account details are:<br/>Username: {0}<br/>Password: {1}",user.Email, user.PasswordHash));

                return user;
        }
    }
}
