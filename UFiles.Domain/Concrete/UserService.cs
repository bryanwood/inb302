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
        private IRepository<User> userRepo;
        private IUnitOfWork unitOfWork;

        public UserService()
        {
            userRepo = new Repository<User>();
            unitOfWork = new UnitOfWork();
            userRepo.UnitOfWork = unitOfWork;
        }

        public Entities.User GetUserByEmail(string email)
        {
            return userRepo.Where(u => u.Email == email).Single();
        }

        public Entities.User GetUserById(int id)
        {
            return userRepo.Where(u => u.UserId == id).Single();
        }

        public void DeleteUser(int id)
        {
        
                var user = userRepo.Where(u => u.UserId == id).Single();
                userRepo.Delete(user);
                unitOfWork.Commit();
      
           
        }

        public IQueryable<Entities.User> GetAllUsers()
        {
            return userRepo.All();
        }

        public void SaveUser(Entities.User user)
        {
                if (user.UserId == 0)
                {
                    userRepo.Add(user);
                }
                else
                {
                    userRepo.Update(user);
                }
                unitOfWork.Commit();
        }

        public bool ChangePassword(string email, string newPassword)
        {
            try
            {
                var user = userRepo.Where(u => u.Email == email).Single();
                user.PasswordHash = newPassword;
                userRepo.Update(user);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User CreateUser(Entities.User user)
        {
                userRepo.Add(user);
                unitOfWork.Commit();
                return user;
        }
    }
}
