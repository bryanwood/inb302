using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using UFiles.Domain.Abstract;
using UFiles.Domain.Concrete;
using UFiles.Domain.Entities;
using Ninject;

namespace UFiles.Web
{
    public class UFilesRoleProvider : RoleProvider
    {
        [Inject]
        public IUnitOfWork UnitOfWork
        {
            set
            {
                this.unitOfWork = value;
            }
        }
        private IUnitOfWork unitOfWork;

        public UFilesRoleProvider()
        {
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            foreach(var roleName in roleNames){
                var role = unitOfWork.RoleRepository.All().Where(r => r.Name == roleName).Single();
                foreach (var username in usernames)
                {
                    var user = unitOfWork.UserRepository.All().Where(u => u.Email == username).Single();
                    role.Users.Add(user);
                }
                unitOfWork.RoleRepository.Update(role);
            }
            unitOfWork.Save();
        }
        private string _applicationName;
        public override string ApplicationName
        {
            get
            {
                return _applicationName;
            }
            set
            {
                if (_applicationName != value)
                {
                    _applicationName = value;
                }
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            var users = unitOfWork.UserRepository.All().Where(u => u.Role.Name == roleName);
            return users.Select(u => u.Email).ToArray();
        }

        public override string[] GetAllRoles()
        {
            return unitOfWork.RoleRepository.All().Select(r => r.Name).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            return new string[] { unitOfWork.UserRepository.All().Where(u => u.Email == username).Single().Role.Name };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return unitOfWork.RoleRepository.All().Where(r => r.Name == roleName).Single().Users.Select(u => u.Email).ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return unitOfWork.UserRepository.All().Where(u => u.Email == username).Single().Role.Name == roleName;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            foreach (var username in usernames)
            {
                var user = unitOfWork.UserRepository.All().Where(u => u.Email == username).Single();
                if (roleNames.Contains(user.Role.Name))
                {
                    user.Role = null;
                }
                unitOfWork.UserRepository.Update(user);
            }
            unitOfWork.Save();
        }

        public override bool RoleExists(string roleName)
        {
            return unitOfWork.RoleRepository.All().Where(r => r.Name == roleName).Count() > 0;
        }
    }
}