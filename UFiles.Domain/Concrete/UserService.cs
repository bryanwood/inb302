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

        public bool DeleteUser(int id)
        {
            try
            {
                var user = userRepo.Where(u => u.UserId == id).Single();
                userRepo.Delete(user);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Entities.User> GetAllUsers()
        {
            return userRepo.All();
        }

        public bool SaveUser(Entities.User user)
        {
            try
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
                return true;
            }
            catch
            {
                return false;
            }
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

        public bool CreateUser(Entities.User user)
        {
            try
            {
                userRepo.Add(user);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
