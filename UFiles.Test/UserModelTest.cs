using UFiles.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using UFiles.Domain.Entities;
using UFiles.Domain.Concrete;

namespace UFiles.Test
{


    /// <summary>
    ///This is a test class for UserModelTest and is intended
    ///to contain all UserModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserModelTest
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
        ///A test for UserModel Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void UserModelConstructorTest()
        {
            int expected = 1;
            User thisUser = new UserService(new UFileContext(), new EmailService()).GetUserById(expected);
            UserModel target = new UserModel(thisUser);
            Assert.AreEqual(target.ID, expected);
        }

        /// <summary>
        ///A test for Email
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void EmailTest()
        {
            int userID = 1;
            User thisUser = new UserService(new UFileContext(), new EmailService()).GetUserById(userID);
            UserModel target = new UserModel(thisUser);
            string expected = new UserService(new UFileContext(), new EmailService()).GetUserById(userID).Email;
            string actual = thisUser.Email;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FName
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void FNameTest()
        {
            int userID = 1;
            User thisUser = new UserService(new UFileContext(), new EmailService()).GetUserById(userID);
            UserModel target = new UserModel(thisUser);
            string expected = new UserService(new UFileContext(), new EmailService()).GetUserById(userID).FirstName;
            string actual = thisUser.FirstName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ID
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void IDTest()
        {
            int userID = 1;
            User thisUser = new UserService(new UFileContext(), new EmailService()).GetUserById(userID);
            UserModel target = new UserModel(thisUser);
            int expected = new UserService(new UFileContext(), new EmailService()).GetUserById(userID).UserId;
            int actual = thisUser.UserId;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LName
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost:58314")]
        public void LNameTest()
        {
            int userID = 1;
            User thisUser = new UserService(new UFileContext(), new EmailService()).GetUserById(userID);
            UserModel target = new UserModel(thisUser);
            string expected = new UserService(new UFileContext(), new EmailService()).GetUserById(userID).LastName;
            string actual = thisUser.LastName;
            Assert.AreEqual(expected, actual);
        }
    }
}
