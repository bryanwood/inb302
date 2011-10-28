using UFiles.Domain.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using System.Linq;
using Moq;
namespace UFiles.Test
{
    
    
    /// <summary>
    ///This is a test class for UserServiceTest and is intended
    ///to contain all UserServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserServiceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for UserService Constructor
        ///</summary>
        [TestMethod()]
        public void UserServiceConstructorTest()
        {
            
            IUnitOfWork unitOfWork =  null; // TODO: Initialize to an appropriate value
            IEmailService emailService = null; // TODO: Initialize to an appropriate value
            UserService target = new UserService(unitOfWork, emailService);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ChangePassword
        ///</summary>
        [TestMethod()]
        public void ChangePasswordTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            IEmailService emailService = null; // TODO: Initialize to an appropriate value
            UserService target = new UserService(unitOfWork, emailService); // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            string newPassword = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ChangePassword(email, newPassword);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateUser
        ///</summary>
        [TestMethod()]
        public void CreateUserTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            IEmailService emailService = null; // TODO: Initialize to an appropriate value
            UserService target = new UserService(unitOfWork, emailService); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            User expected = null; // TODO: Initialize to an appropriate value
            User actual;
            actual = target.CreateUser(user);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeleteUser
        ///</summary>
        [TestMethod()]
        public void DeleteUserTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            IEmailService emailService = null; // TODO: Initialize to an appropriate value
            UserService target = new UserService(unitOfWork, emailService); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            target.DeleteUser(id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetAllUsers
        ///</summary>
        [TestMethod()]
        public void GetAllUsersTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            IEmailService emailService = null; // TODO: Initialize to an appropriate value
            UserService target = new UserService(unitOfWork, emailService); // TODO: Initialize to an appropriate value
            IQueryable<User> expected = null; // TODO: Initialize to an appropriate value
            IQueryable<User> actual;
            actual = target.GetAllUsers();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUserByEmail
        ///</summary>
        [TestMethod()]
        public void GetUserByEmailTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            IEmailService emailService = null; // TODO: Initialize to an appropriate value
            UserService target = new UserService(unitOfWork, emailService); // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            User expected = null; // TODO: Initialize to an appropriate value
            User actual;
            actual = target.GetUserByEmail(email);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUserById
        ///</summary>
        [TestMethod()]
        public void GetUserByIdTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            IEmailService emailService = null; // TODO: Initialize to an appropriate value
            UserService target = new UserService(unitOfWork, emailService); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            User expected = null; // TODO: Initialize to an appropriate value
            User actual;
            actual = target.GetUserById(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SaveUser
        ///</summary>
        [TestMethod()]
        public void SaveUserTest()
        {
            IUnitOfWork unitOfWork = null; // TODO: Initialize to an appropriate value
            IEmailService emailService = null; // TODO: Initialize to an appropriate value
            UserService target = new UserService(unitOfWork, emailService); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            target.SaveUser(user);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
