using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using UFiles.Domain.Abstract;
using UFiles.Domain.Concrete;
using System.Security.Cryptography;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Web
{
    public class UFilesMembershipProvider : MembershipProvider
    {

        private IUserService userService;
        private IUnitOfWork _unitOfWork;
        public UFilesMembershipProvider()
        {
            userService = new UserService();
            
        }
        private string _applicationName = "UFiles";
        public override string ApplicationName
        {
            get
            {
                return _applicationName;
            }
            set
            {
                if (value != _applicationName)
                {
                    _applicationName = value;
                }
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            if (oldPassword != newPassword)
            {
                return userService.ChangePassword(username, newPassword); ;
            }
            return false;
        }
        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            var user = new User();
            user.Email = email;
            user.PasswordHash = password;
            userService.CreateUser(user);
            
            var membershipUser = new MembershipUser("UFilesMembershipProvider",email,user.UserId,email,"","",true,false,DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            status = MembershipCreateStatus.Success;
            return membershipUser;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }
        private bool _enablePasswordReset = false;
        public override bool EnablePasswordReset
        {
            get { return _enablePasswordReset; }
        }
        private bool _enablePasswordRetrieval = false;
        public override bool EnablePasswordRetrieval
        {
            get { return _enablePasswordRetrieval; }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            try
            {
                var user = userService.GetUserByEmail(username);
                if (user!=null)
                {
                    return new MembershipUser("UFilesMembershipProvider", username, user.UserId, username, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
                }
                else
                {
                    return null;
                }
            }
            catch (InvalidOperationException)
            {
                return null;
            }

        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }
        private int _maxInvalidPasswordAttempts = 5;
        public override int MaxInvalidPasswordAttempts
        {
            get { return _maxInvalidPasswordAttempts; }
        }
        private int _minRequiredNonAlphanumericCharacters = 0;
        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return _minRequiredNonAlphanumericCharacters; }
        }
        private int _minRequiredPasswordLength = 1;
        public override int MinRequiredPasswordLength
        {
            get { return _minRequiredPasswordLength; }
        }
        private int _passwordAttemptWindow = 5;
        public override int PasswordAttemptWindow
        {
            get { return _passwordAttemptWindow; }
        }
        private MembershipPasswordFormat _passwordFormat = MembershipPasswordFormat.Hashed;
        public override MembershipPasswordFormat PasswordFormat
        {
            get { return _passwordFormat; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
        private bool _requriesQuestionAndAnswer = false;
        public override bool RequiresQuestionAndAnswer
        {
            get { return _requriesQuestionAndAnswer; }
        }
        private bool _requiresUniqueEmail = true;
        public override bool RequiresUniqueEmail
        {
            get { return _requiresUniqueEmail; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            var pass = password;
            var user = userService.GetUserByEmail(username);
            if (user.PasswordHash==password)
            {
                return true;
            }
            return false;
        }
    }
}