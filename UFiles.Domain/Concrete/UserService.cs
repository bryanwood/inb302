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
        private IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Entities.User GetUserByEmail(string email)
        {
            return unitOfWork.UserRepository.Where(u => u.Email == email).Single();
        }

        public Entities.User GetUserById(int id)
        {
            return unitOfWork.UserRepository.Where(u => u.UserId == id).Single();
        }

        public void DeleteUser(int id)
        {

            var user = unitOfWork.UserRepository.Where(u => u.UserId == id).Single();
                unitOfWork.UserRepository.Delete(user);
                unitOfWork.Save();
      
           
        }

        public IQueryable<Entities.User> GetAllUsers()
        {
            return unitOfWork.UserRepository.All();
        }

        public void SaveUser(Entities.User user)
        {
                if (user.UserId == 0)
                {
                    unitOfWork.UserRepository.Add(user);
                }
                else
                {
                    unitOfWork.UserRepository.Update(user);
                }
                unitOfWork.Save();
        }

        public bool ChangePassword(string email, string newPassword)
        {
            try
            {
                var user = unitOfWork.UserRepository.Where(u => u.Email == email).Single();
                user.PasswordHash = newPassword;
                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User CreateUser(Entities.User user)
        {
                unitOfWork.UserRepository.Add(user);
                unitOfWork.Save();
                return user;
        }
    }
}
