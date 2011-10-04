using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using UFiles.Domain.Abstract;
using UFiles.Domain.Concrete;
using UFiles.Domain.Entities;

namespace UFiles.Web
{
    public class UFilesRoleProvider : RoleProvider
    {
        private UnitOfWork _unitOfWork;
        private IRepository<User> _userRepo;
        private IRepository<Role> _roleRepo;

        public UFilesRoleProvider()
        {
            _userRepo = new Repository<User>();
            _roleRepo = new Repository<Role>();
            
            _unitOfWork = new UnitOfWork();

            _userRepo.UnitOfWork = _unitOfWork;
            _roleRepo.UnitOfWork = _unitOfWork;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            foreach(var roleName in roleNames){
                var role = _roleRepo.All().Where(r => r.Name == roleName).Single();
                foreach (var username in usernames)
                {
                    var user = _userRepo.All().Where(u => u.Email == username).Single();
                    role.Users.Add(user);
                }
                _roleRepo.Update(role);
            }
            _unitOfWork.Commit();
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
            var users = _userRepo.All().Where(u => u.Role.Name == roleName);
            return users.Select(u => u.Email).ToArray();
        }

        public override string[] GetAllRoles()
        {
            return _roleRepo.All().Select(r => r.Name).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            return new string[] { _userRepo.All().Where(u => u.Email == username).Single().Role.Name };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return _roleRepo.All().Where(r => r.Name == roleName).Single().Users.Select(u => u.Email).ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return _userRepo.All().Where(u => u.Email == username).Single().Role.Name == roleName;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            foreach (var username in usernames)
            {
                var user = _userRepo.All().Where(u => u.Email == username).Single();
                if (roleNames.Contains(user.Role.Name))
                {
                    user.Role = null;
                }
                _userRepo.Update(user);
            }
            _unitOfWork.Commit();
        }

        public override bool RoleExists(string roleName)
        {
            return _roleRepo.All().Where(r => r.Name == roleName).Count() > 0;
        }
    }
}