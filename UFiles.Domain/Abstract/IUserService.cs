using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    
    public interface IUserService
    {
        /// <summary>
        /// Gets a user by thier email address
        /// </summary>
        /// <param name="email">the email address to get the user by</param>
        /// <returns>A user</returns>
        User GetUserByEmail(string email);

        /// <summary>
        /// gets a user by thier id
        /// </summary>
        /// <param name="id">the id to get the user by</param>
        /// <returns>A user</returns>
        User GetUserById(int id);
        
        /// <summary>
        /// deletes a user
        /// </summary>
        /// <param name="id">the id of the user to delete</param>
        void DeleteUser(int id);

        /// <summary>
        /// gets a list of all the users
        /// </summary>
        /// <returns>a list of User</returns>
        IQueryable<User> GetAllUsers();

        /// <summary>
        /// saves changes to a user
        /// </summary>
        /// <param name="user">the user to save</param>
        void SaveUser(User user);

        /// <summary>
        /// Chanages a users password
        /// </summary>
        /// <param name="email">the email of the user</param>
        /// <param name="newPassword">the new password</param>
        /// <returns>if the change succeded</returns>
        bool ChangePassword(string email, string newPassword);

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">the user to create</param>
        /// <returns>the created user</returns>
        User CreateUser(User user);
    }
}
